using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Helpers;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class LeaveTrackingImp : ILeaveTracking
    {
        private readonly HRMSContext _hrmsContext;
        private readonly IAlertEmailOperations _alertEmail;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtUtils _jwtUtils;
        private List<string>? dToken;
        private int? _decodedToken;
        private readonly IAzureOperations _azureOperations;

        public LeaveTrackingImp(HRMSContext hrmscontext, IHttpContextAccessor httpContextAccessor, IJwtUtils jwtUtils, IAlertEmailOperations alertEmail,IAzureOperations azureOperations)
        {
            _hrmsContext = hrmscontext;
            _httpContextAccessor = httpContextAccessor;
            _jwtUtils = jwtUtils;
            _alertEmail = alertEmail;
            _azureOperations = azureOperations;
        }
        private void DecodeToken()
        {
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (string.IsNullOrEmpty(token))
            {
                dToken = null;
            }
            else
            {
                var userId = _jwtUtils.ValidateJwtToken(token);
                if (userId.HasValue)
                {
                    var userDetails = _hrmsContext.EmployeeCredentials.FirstOrDefault(e => e.Id == userId.Value);
                    if (userDetails != null)
                    {
                        _decodedToken = userDetails.Id;
                        dToken = userDetails.UserRolesJs.Select(ur => ur.Roles.Name).ToList();
                    }
                    else
                    {
                        dToken = null;
                    }
                }
            }
        }

        public async Task<IEnumerable<LeaveTracking>> GetAllAsync()
        {
            var result = await (from row in _hrmsContext.LeaveTrackings
                                where row.IsActive == 1
                                select row).ToListAsync();
            return result;
        }

        public LeaveTracking GetByIdAsync(int id)
        {
            var res = (from row in _hrmsContext.LeaveTrackings
                       where row.Id == id && row.IsActive == 1
                       select row).FirstOrDefault();
            return res ?? new LeaveTracking();
        }


        public async Task<LeaveTracking> UpdateAsync(LeaveTracking leaveTracking)
        {
             DecodeToken();

            _hrmsContext.LeaveTrackings.Update(leaveTracking);
            await _hrmsContext.SaveChangesAsync(_decodedToken);
            return leaveTracking;
        }
        public async Task<LeaveTracking> CreateAsync(LeaveTracking leaveTracking, int empCredentialId)
        {
            DecodeToken();
            leaveTracking.EmpCredentialId = empCredentialId;

            // Check for overlapping leave
            var overlappingLeave = await _hrmsContext.LeaveTrackings
                .Where(lt => lt.EmpCredentialId == empCredentialId &&
                             (lt.Status == "Pending" || lt.Status == "Approved") &&
                             (
                                 (leaveTracking.Startdate >= lt.Startdate && leaveTracking.Startdate <= lt.Enddate) ||
                                 (leaveTracking.Enddate >= lt.Startdate && leaveTracking.Enddate <= lt.Enddate) ||
                                 (leaveTracking.Startdate <= lt.Startdate && leaveTracking.Enddate >= lt.Enddate) ||
                                 (leaveTracking.Startdate <= lt.Enddate && leaveTracking.Enddate > lt.Enddate)
                             )).FirstOrDefaultAsync();

            if (overlappingLeave != null)
            {
                string overlapStatusMessage = overlappingLeave.Status == "Pending"
                    ? $"There is already a pending leave request for the dates {overlappingLeave.Startdate?.ToString("yyyy-MM-dd")} to {overlappingLeave.Enddate?.ToString("yyyy-MM-dd")}."
                    : $"There is already an approved leave request for the dates {overlappingLeave.Startdate?.ToString("yyyy-MM-dd")} to {overlappingLeave.Enddate?.ToString("yyyy-MM-dd")}.";
                throw new Exception(overlapStatusMessage);
            }

            // Add new leave request
            await _hrmsContext.LeaveTrackings.AddAsync(leaveTracking);
            await _hrmsContext.SaveChangesAsync(_decodedToken);

            // Fetch Employee Information
            var empInfo = await (from ec in _hrmsContext.EmployeeCredentials
                                 where ec.Id == empCredentialId
                                 select new
                                 {
                                     Email = ec.Email,
                                     UserName = ec.UserName
                                 }).FirstOrDefaultAsync();

            if (empInfo == null)
            {
                throw new Exception("Employee information not found.");
            }

            string employeeBodyMessage = "Your leave request has been successfully submitted and is pending approval.";
            var employeeParameters = new Dictionary<string, string>
            {
                { "To", empInfo.Email },
                { "Subject", "Leave Request Received" },
                { "Name", empInfo.UserName },
                { "StartDate", leaveTracking.Startdate?.ToString("yyyy-MM-dd") ?? string.Empty },
                { "EndDate", leaveTracking.Enddate?.ToString("yyyy-MM-dd") ?? string.Empty },
                { "BodyMessage", employeeBodyMessage }
            };

            string employeeEmailTemplate = constants.LeaveNotificationTemplate;
            foreach (var param in employeeParameters)
            {
                employeeEmailTemplate = employeeEmailTemplate.Replace($"{{{{{param.Key}}}}}", param.Value);
            }

            await _alertEmail.SendEmailAsync(employeeEmailTemplate, employeeParameters);

            var managerInfo = await (from ed in _hrmsContext.EmployeeDetails
                                     join ec in _hrmsContext.EmployeeCredentials
                                     on ed.ManagerId equals ec.Id
                                     where ed.EmployeeCredentialId == empCredentialId
                                     select new
                                     {
                                         ManagerEmail = ec.Email,
                                         ManagerName = ec.UserName
                                     }).FirstOrDefaultAsync();

            if (managerInfo != null)
            {
                string managerBodyMessage = $"{empInfo.UserName} has submitted a leave request for {leaveTracking.Startdate?.ToString("yyyy-MM-dd")} to {leaveTracking.Enddate?.ToString("yyyy-MM-dd")} and is awaiting your approval.";
                var managerParameters = new Dictionary<string, string>
                {
                    { "To", managerInfo.ManagerEmail },
                    { "Subject", "Leave Request Pending Approval" },
                    { "Name", managerInfo.ManagerName },
                    { "StartDate", leaveTracking.Startdate?.ToString("yyyy-MM-dd") ?? string.Empty },
                    { "EndDate", leaveTracking.Enddate?.ToString("yyyy-MM-dd") ?? string.Empty },
                    { "BodyMessage", managerBodyMessage }
                };

                string managerEmailTemplate = constants.LeaveNotificationTemplate;
                foreach (var param in managerParameters)
                {
                    managerEmailTemplate = managerEmailTemplate.Replace($"{{{{{param.Key}}}}}", param.Value);
                }
                await _alertEmail.SendEmailAsync(managerEmailTemplate, managerParameters);
            }

            return leaveTracking;
        }

        public async Task<LeaveTracking> UpdateLeaveAsync(int id, string newStatus)
        {
            var leaveTracking = await (from row in _hrmsContext.LeaveTrackings
                                       where row.Id == id
                                       select row).FirstOrDefaultAsync();

            if (leaveTracking != null)
            {
                leaveTracking.Status = newStatus;

                if (newStatus == "Approved" && leaveTracking.Startdate.HasValue && leaveTracking.Enddate.HasValue)
                {
                    var empCredentialId = leaveTracking.EmpCredentialId;

                    var leaveAllocation = await (from row in _hrmsContext.EmployeeLeaveAllocations
                                                 where row.EmpCredentialId == empCredentialId && row.IsActive == 1
                                                 select row).FirstOrDefaultAsync();

                    if (leaveAllocation != null)
                    {
                        int totalLeaveDays = (leaveTracking.Enddate.Value - leaveTracking.Startdate.Value).Days + 1;

                        var remainingLeave = leaveAllocation.RemainingLeave - totalLeaveDays;

                        if (leaveAllocation.RemainingLeave > 0)
                            leaveAllocation.RemainingLeave = remainingLeave;
                    }
                }
            }

                var empInfo = await (from lt in _hrmsContext.LeaveTrackings
                                     join ec in _hrmsContext.EmployeeCredentials
                                     on lt.EmpCredentialId equals ec.Id
                                     where lt.Id == id
                                     select new
                                     {
                                         Email = ec.Email,
                                         UserName = ec.UserName,
                                         StartDate = lt.Startdate,
                                         EndDate = lt.Enddate,
                                         EmpCredentialId = ec.Id
                                     }).FirstOrDefaultAsync();

                if (empInfo == null)
                {
                    throw new Exception("Employee information not found.");
                }

                var employeeParameters = new Dictionary<string, string>
                {
                    { "To", empInfo.Email },
                    { "EmployeeName", empInfo.UserName },
                    { "StartDate", empInfo.StartDate?.ToString("yyyy-MM-dd") ?? string.Empty },
                    { "EndDate", empInfo.EndDate?.ToString("yyyy-MM-dd") ?? string.Empty }
                };
                string employeeBodyMessage = string.Empty;

                var managerInfo = await (from ed in _hrmsContext.EmployeeDetails
                                         join ec in _hrmsContext.EmployeeCredentials
                                         on ed.ManagerId equals ec.Id
                                         where ed.EmployeeCredentialId == empInfo.EmpCredentialId
                                         select new
                                         {
                                             ManagerEmail = ec.Email
                                         }).FirstOrDefaultAsync();

                string managerBodyMessage = string.Empty;

                switch (newStatus.ToLower())
                {
                    case "approved":
                        employeeParameters["Subject"] = "Your Leave Request has been Approved";
                        employeeBodyMessage = "Your leave request has been approved. Enjoy your time off!";

                        if (managerInfo != null)
                        {
                            managerBodyMessage = $"{empInfo.UserName}'s leave request has been approved.";
                        }
                        break;
                    case "rejected":
                        employeeParameters["Subject"] = "Your Leave Request has been Rejected";
                        employeeBodyMessage = "Unfortunately, your leave request has been rejected. Please contact your manager for more details.";

                        if (managerInfo != null)
                        {
                            managerBodyMessage = $"{empInfo.UserName}'s leave request has been rejected.";
                        }
                        break;
                    case "withdraw":
                        employeeParameters["Subject"] = "Your Leave Request has been Withdrawn";
                        employeeBodyMessage = "You have successfully withdrawn your leave request. If you have any concerns, feel free to contact your manager.";

                        if (managerInfo != null)
                        {
                            managerBodyMessage = $"{empInfo.UserName} has withdrawn their leave request.";
                        }
                        break;
                    case "pending":
                        employeeParameters["Subject"] = "Your Leave Request is Currently Pending";
                        employeeBodyMessage = "We regret to inform you that your leave request is currently pending. If you have any concerns, feel free to contact your manager.";

                        if (managerInfo != null)
                        {
                            managerBodyMessage = $"{empInfo.UserName}'s leave request is currently pending. Please review and take action as needed.";
                        }
                        break;
                    default:
                        throw new Exception("Invalid status for email notification.");
                }

                employeeParameters["BodyMessage"] = employeeBodyMessage;

                string employeeEmailTemplate = constants.LeaveNotificationTemplate;
                foreach (var param in employeeParameters)
                {
                    employeeEmailTemplate = employeeEmailTemplate.Replace($"{{{{{param.Key}}}}}", param.Value);
                }
                await _alertEmail.SendEmailAsync(employeeEmailTemplate, employeeParameters);

                // Send Email to Manager (if Manager Info is Available)
                if (managerInfo != null)
                {
                    var managerParameters = new Dictionary<string, string>
                    {
                        { "To", managerInfo.ManagerEmail },
                        { "Subject", employeeParameters["Subject"] },
                        { "EmployeeName", empInfo.UserName },
                        { "StartDate", empInfo.StartDate?.ToString("yyyy-MM-dd") ?? string.Empty },
                        { "EndDate", empInfo.EndDate?.ToString("yyyy-MM-dd") ?? string.Empty },
                        { "BodyMessage", managerBodyMessage }
                    };

                    string managerEmailTemplate = constants.LeaveNotificationTemplate;
                    foreach (var param in managerParameters)
                    {
                        managerEmailTemplate = managerEmailTemplate.Replace($"{{{{{param.Key}}}}}", param.Value);
                    }
                    await _alertEmail.SendEmailAsync(managerEmailTemplate, managerParameters);
                }

                _hrmsContext.LeaveTrackings.Update(leaveTracking);
                await _hrmsContext.SaveChangesAsync();

            return leaveTracking;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            DecodeToken();
            var leaveTracking = await _hrmsContext.LeaveTrackings.FindAsync(id);
            if (leaveTracking == null)
            {
                return false;
            }

            _hrmsContext.LeaveTrackings.Remove(leaveTracking);
            await _hrmsContext.SaveChangesAsync(_decodedToken);
            return true;
        }
        public async Task<List<LeaveApprovalDTO>> GetLeavesByStatusAsync(string status, int managerId)
        {
            var leaves = await (from leave in _hrmsContext.LeaveTrackings
                                join emp in _hrmsContext.EmployeeDetails on leave.EmpCredentialId equals emp.EmployeeCredentialId
                                join leaveType in _hrmsContext.LeaveTypes on leave.LeaveTypeId equals leaveType.Id
                                where leave.Status == status
                                      && emp.ManagerId == managerId
                                      && emp.IsActive == 1
                                      && leave.IsActive == 1
                                      && leaveType.Type != "Regularization"
                                select new LeaveApprovalDTO
                                {
                                    Id = leave.Id,
                                    EmployeeNumber = emp.EmployeeNumber,
                                    Name = $"{emp.FirstName} {emp.LastName}",
                                    LeaveType = leaveType.Type,
                                    StartDate = leave.Startdate ?? DateTime.MinValue,
                                    EndDate = leave.Enddate ?? DateTime.MinValue,
                                    NoofDays = (leave.Enddate.HasValue && leave.Startdate.HasValue)
                                        ? (int)(leave.Enddate.Value - leave.Startdate.Value).TotalDays + 1
                                        : 0
                                }).ToListAsync();

            return leaves;
        }


        public async Task<LeaveSummaryDTO> GetEmployeeLeaveSummaryAsync(int employeeCredentialId)
        {
            var allLeaveDetails = await _hrmsContext.LeaveTrackings
                .Where(l => l.EmpCredentialId == employeeCredentialId)
                .ToListAsync();

            var totalApprovedCount = allLeaveDetails.Count(l => l.Status == "Approved");
            var totalPendingCount = allLeaveDetails.Count(l => l.Status == "Pending");
            var totalRejectedCount = allLeaveDetails.Count(l => l.Status == "Rejected");


            var leaveAllocations = await _hrmsContext.EmployeeLeaveAllocations
                .Where(e => e.EmpCredentialId == employeeCredentialId)
                .ToListAsync();


            var leaveSummaries = leaveAllocations.Select(allocation => new LeaveSummaryDTO
            {
                LeaveType = _hrmsContext.LeaveTypes.FirstOrDefault(lt => lt.Id == allocation.LeaveType)?.Type ?? "Unknown",
                TotalAllocatedLeaves = allocation.NumberOfLeaves ?? 0,
                ApprovedLeaves = allLeaveDetails
                    .Where(l => l.LeaveTypeId == allocation.LeaveType && l.Status == "Approved")
                    .Sum(l => (l.Enddate.HasValue && l.Startdate.HasValue)
                            ? (int)(l.Enddate.Value - l.Startdate.Value).TotalDays + 1
                            : 0),
                PendingLeaves = allLeaveDetails
                    .Where(l => l.LeaveTypeId == allocation.LeaveType && l.Status == "Pending")
                    .Sum(l => (l.Enddate.HasValue && l.Startdate.HasValue)
                            ? (int)(l.Enddate.Value - l.Startdate.Value).TotalDays + 1
                            : 0),
                RejectedLeaves = allLeaveDetails
                    .Where(l => l.LeaveTypeId == allocation.LeaveType && l.Status == "Rejected")
                    .Sum(l => (l.Enddate.HasValue && l.Startdate.HasValue)
                            ? (int)(l.Enddate.Value - l.Startdate.Value).TotalDays + 1
                            : 0),
                RemainingLeaves = allocation.NumberOfLeaves.HasValue
                    ? allocation.NumberOfLeaves.Value - allLeaveDetails
                        .Where(l => l.LeaveTypeId == allocation.LeaveType && l.Status == "Approved")
                        .Sum(l => (l.Enddate.HasValue && l.Startdate.HasValue)
                                ? (int)(l.Enddate.Value - l.Startdate.Value).TotalDays + 1
                                : 0)
                    : 0,
                ApprovedCount = totalApprovedCount,
                PendingCount = totalPendingCount,
                RejectedCount = totalRejectedCount
            }).ToList();

            var totalApprovedLeaves = leaveSummaries.Sum(x => x.ApprovedLeaves);
            var totalPendingLeaves = leaveSummaries.Sum(x => x.PendingLeaves);
            var totalRejectedLeaves = leaveSummaries.Sum(x => x.RejectedLeaves);
            var totalRemainingLeaves = leaveSummaries.Sum(x => x.RemainingLeaves);
            var totalAllocatedLeaves = leaveSummaries.Sum(x => x.TotalAllocatedLeaves);

            return new LeaveSummaryDTO
            {
                LeaveType = "All Leave Types",
                TotalAllocatedLeaves = totalAllocatedLeaves,
                ApprovedLeaves = totalApprovedLeaves,
                PendingLeaves = totalPendingLeaves,
                RejectedLeaves = totalRejectedLeaves,
                RemainingLeaves = totalRemainingLeaves,
                ApprovedCount = totalApprovedCount,
                PendingCount = totalPendingCount,
                RejectedCount = totalRejectedCount,
                LeaveSummaries = leaveSummaries
            };
        }
        public bool SoftDelete(int id, short isActive)
        {
            var res = (from row in _hrmsContext.LeaveTrackings
                       where row.Id == id
                       select row).FirstOrDefault();
            if (res != null)
            {
                res.IsActive = isActive;
                _hrmsContext.LeaveTrackings.Update(res);
                _hrmsContext.SaveChanges();
                return true;

            }
            return false;
        }
       
        public async Task<LeaveTracking> ApllyLeaveBehalf(LeaveTracking leaveTracking, int empCredentialId)
        {
             DecodeToken();

            leaveTracking.EmpCredentialId = empCredentialId;

             var leaveAllocation = await (from row in _hrmsContext.EmployeeLeaveAllocations
                                     where row.EmpCredentialId == empCredentialId && row.IsActive == 1
                                     select row).FirstOrDefaultAsync();

            var leaveType = await _hrmsContext.LeaveTypes
            .Where(lt => lt.Id == leaveTracking.LeaveTypeId && lt.IsActive == 1)
            .FirstOrDefaultAsync();

        var overlappingLeave = await _hrmsContext.LeaveTrackings
            .Where(lt => lt.EmpCredentialId == empCredentialId &&
                         ((leaveTracking.Startdate >= lt.Startdate && leaveTracking.Startdate <= lt.Enddate) ||
                          (leaveTracking.Enddate >= lt.Startdate && leaveTracking.Enddate <= lt.Enddate) ||
                          (leaveTracking.Startdate <= lt.Startdate && leaveTracking.Enddate >= lt.Enddate)))
            .Select(lt => new { lt.Status, lt.Startdate, lt.Enddate })
            .FirstOrDefaultAsync();

        if (overlappingLeave != null)
        {
            if (overlappingLeave.Status == "Pending")
            {
                throw new Exception($"There is already a pending leave request for the dates {overlappingLeave.Startdate?.ToString("yyyy-MM-dd")} to {overlappingLeave.Enddate?.ToString("yyyy-MM-dd")}.");
            }
            else if (overlappingLeave.Status == "Approved")
            {
                throw new Exception($"There is already an approved leave request for the dates {overlappingLeave.Startdate?.ToString("yyyy-MM-dd")} to {overlappingLeave.Enddate?.ToString("yyyy-MM-dd")}.");
            }
        }

        if (leaveAllocation != null && leaveType != null)
        {
            int totalLeaveDays = (leaveTracking.Enddate.Value - leaveTracking.Startdate.Value).Days + 1;

            if (leaveType.Days < totalLeaveDays)
            {
                throw new InvalidOperationException($"Requested leave exceeds the allowed limit for {leaveType.Type}. Maximum allowed: {leaveType.Days} days.");
            }

            if (leaveAllocation.RemainingLeave < totalLeaveDays)
            {
                throw new InvalidOperationException("Requested leave exceeds remaining leave.");
            }

            if (leaveTracking.Status == "Pending")
            {
                leaveAllocation.RemainingLeave -= totalLeaveDays;

                await _hrmsContext.SaveChangesAsync(_decodedToken);
            }
        }

        await _hrmsContext.LeaveTrackings.AddAsync(leaveTracking);
        await _hrmsContext.SaveChangesAsync(_decodedToken);

        var empInfo = await (from lt in _hrmsContext.LeaveTrackings
                             join ec in _hrmsContext.EmployeeCredentials
                             on lt.EmpCredentialId equals ec.Id
                             where lt.EmpCredentialId == empCredentialId
                             select new
                             {
                                 Email = ec.Email,
                                 UserName = ec.UserName,
                                 StartDate = lt.Startdate,
                                 EndDate = lt.Enddate
                             }).FirstOrDefaultAsync();

            if (empInfo == null)
            {
                throw new Exception("Employee information not found.");
            }

            var parameters = new Dictionary<string, string>
            {
                { "To", empInfo.Email },
                { "EmployeeName", empInfo.UserName },
                { "StartDate", empInfo.StartDate?.ToString("yyyy-MM-dd") ?? string.Empty },
                { "EndDate", empInfo.EndDate?.ToString("yyyy-MM-dd") ?? string.Empty }
            };

            string emailTemplate = constants.LeaveNotificationTemplate;

            string bodyMessage = "A leave request has been successfully applied on your behalf and is pending approval.";

            parameters["Subject"] = "Leave Request Applied on Your Behalf";
            parameters["BodyMessage"] = bodyMessage;

            foreach (var param in parameters)
            {
                emailTemplate = emailTemplate.Replace($"{{{{{param.Key}}}}}", param.Value);
            }

            await _alertEmail.SendEmailAsync(emailTemplate, parameters);
            await _hrmsContext.SaveChangesAsync();

            return leaveTracking;
        }


        public List<LeavePendingDTO> GetPendingLeaves(int employeeCredentialId)
        {
            var pendingLeaves = (from leave in _hrmsContext.LeaveTrackings
                                 join empCred in _hrmsContext.EmployeeCredentials on leave.EmpCredentialId equals empCred.Id
                                 join empDetail in _hrmsContext.EmployeeDetails on empCred.Id equals empDetail.EmployeeCredentialId
                                 join leaveType in _hrmsContext.LeaveTypes on leave.LeaveTypeId equals leaveType.Id
                                 where leave.Status == "Pending" && empCred.Id == employeeCredentialId && leaveType.Type != "Regularization"
                                 select new LeavePendingDTO
                                 {
                                     id = leave.Id,
                                     employeecredentialId = empCred.Id,
                                     Name = empDetail.FirstName + " " + empDetail.LastName,
                                     LeaveType = leaveType.Type,
                                     managername = _hrmsContext.EmployeeDetails
                                        .Where(mgr => mgr.EmployeeCredentialId == empDetail.ManagerId)
                                        .Select(mgr => mgr.FirstName + " " + mgr.LastName).FirstOrDefault(),
                                     Reason = leave.ReasonForLeave,
                                     StartDate = leave.Startdate,
                                     EndDate = leave.Enddate,
                                     Applieddate = leave.AppliedDate,
                                     NoofDays = (leave.Enddate != null && leave.Startdate != null)
                                        ? (leave.Enddate.Value - leave.Startdate.Value).Days + 1
                                        : 0
                                 }).ToList();

              return pendingLeaves;
        }
        
            public List<LeavePendingDTO> GetHistoryLeaves(int employeeCredentialId)
            {
                             var pendingLeaves = (from leave in _hrmsContext.LeaveTrackings
                                 join empCred in _hrmsContext.EmployeeCredentials on leave.EmpCredentialId equals empCred.Id
                                 join empDetail in _hrmsContext.EmployeeDetails on empCred.Id equals empDetail.EmployeeCredentialId
                                 join leaveType in _hrmsContext.LeaveTypes on leave.LeaveTypeId equals leaveType.Id
                                 where (leave.Status == "Rejected" || leave.Status == "Withdrawn" || leave.Status == "Approved")
                                       && empCred.Id == employeeCredentialId && leaveType.Type != "Regularization"
                                select new LeavePendingDTO
                                 {
                                     id = leave.Id,
                                     employeecredentialId = empCred.Id,
                                     Name = empDetail.FirstName + " " + empDetail.LastName,
                                     LeaveType = leaveType.Type,
                                     Reason = leave.ReasonForLeave,
                                     status = leave.Status,
                                     StartDate = leave.Startdate,
                                     EndDate = leave.Enddate,
                                     Applieddate = leave.AppliedDate,
                                     NoofDays = (leave.Enddate != null && leave.Startdate != null)
                                        ? (leave.Enddate.Value - leave.Startdate.Value).Days + 1
                                        : 0
                                 }).ToList();

                            return pendingLeaves;
            }
            public async Task<LeaveTracking> UpdateLeaveAsyncchanges(int employeeCredentialId, int id, string newStatus)
            {
                 var leaveTracking = await _hrmsContext.LeaveTrackings
                .FirstOrDefaultAsync(lt => lt.EmpCredentialId == employeeCredentialId && lt.Id == id);

                 if (leaveTracking != null)
                 {
                    leaveTracking.Status = newStatus;
                    await _hrmsContext.SaveChangesAsync();
                 }

            return leaveTracking;
        }
    }
}
