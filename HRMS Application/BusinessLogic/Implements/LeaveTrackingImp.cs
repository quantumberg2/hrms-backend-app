using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class LeaveTrackingImp : ILeaveTracking
    {
        private readonly HRMSContext _hrmsContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtUtils _jwtUtils;
        private List<string>? dToken;
        private int? _decodedToken;
        public LeaveTrackingImp(HRMSContext hrmscontext, IHttpContextAccessor httpContextAccessor, IJwtUtils jwtUtils)
        {
            _hrmsContext = hrmscontext;
            _httpContextAccessor = httpContextAccessor;
            _jwtUtils = jwtUtils;
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

        public async Task<LeaveTracking> GetByIdAsync(int id)
        {
            var res = (from row in _hrmsContext.LeaveTrackings
                       where row.Id == id && row.IsActive == 1
                       select row).FirstOrDefault();
            return res;
        }

        public async Task<LeaveTracking> CreateAsync(LeaveTracking leaveTracking, int empCredentialId)
        {
            DecodeToken();
            leaveTracking.EmpCredentialId = empCredentialId;

            // Add to the database
            await _hrmsContext.LeaveTrackings.AddAsync(leaveTracking);
            await _hrmsContext.SaveChangesAsync(_decodedToken);

            return leaveTracking;
        }


        public async Task<LeaveTracking> UpdateAsync(LeaveTracking leaveTracking)
        {
             DecodeToken();

            _hrmsContext.LeaveTrackings.Update(leaveTracking);
            await _hrmsContext.SaveChangesAsync(_decodedToken);
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

                await _hrmsContext.SaveChangesAsync();
            }
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
        public async Task<List<LeaveApprovalDTO>> GetLeavesByStatusAsync(string status)
        {
            var leaves = await (from leave in _hrmsContext.LeaveTrackings
                                join emp in _hrmsContext.EmployeeDetails on leave.EmpCredentialId equals emp.EmployeeCredentialId
                                join leaveType in _hrmsContext.LeaveTypes on leave.LeaveTypeId equals leaveType.Id
                                where leave.Status == status
                                select new LeaveApprovalDTO
                                {
                                    Id = leave.Id,
                                    EmployeeNumber = emp.EmployeeNumber,
                                    Name = $"{emp.FirstName} {emp.LastName}",
                                    LeaveType = leaveType.Type, // Assuming 'Name' is a property of LeaveType
                                    StartDate = leave.Startdate ?? DateTime.MinValue,
                                    EndDate = leave.Enddate ?? DateTime.MinValue,
                                    NoofDays = (leave.Enddate.HasValue && leave.Startdate.HasValue)
                                ? (int)(leave.Enddate.Value - leave.Startdate.Value).TotalDays + 1 // Include both start and end dates
                                : 0
                                }).ToListAsync();

            return leaves;
        }
        public async Task<LeaveSummaryDTO> GetEmployeeLeaveSummaryAsync(int employeeCredentialId)
        {
            // Fetch all leave details for the employee
            var allLeaveDetails = await _hrmsContext.LeaveTrackings
                .Where(l => l.EmpCredentialId == employeeCredentialId)
                .ToListAsync();

            // Calculate global counts
            var totalApprovedCount = allLeaveDetails.Count(l => l.Status == "Approved");
            var totalPendingCount = allLeaveDetails.Count(l => l.Status == "Pending");
            var totalRejectedCount = allLeaveDetails.Count(l => l.Status == "Rejected");

            // Fetch leave allocations
            var leaveAllocations = await _hrmsContext.EmployeeLeaveAllocations
                .Where(e => e.EmpCredentialId == employeeCredentialId)
                .ToListAsync();

            // Prepare the summary for individual leave types
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

            // Calculate the aggregated totals for all leave types
            var totalAllocatedLeaves = leaveSummaries.Sum(x => x.TotalAllocatedLeaves);
            var totalApprovedLeaves = leaveSummaries.Sum(x => x.ApprovedLeaves);
            var totalPendingLeaves = leaveSummaries.Sum(x => x.PendingLeaves);
            var totalRejectedLeaves = leaveSummaries.Sum(x => x.RejectedLeaves);
            var totalRemainingLeaves = leaveSummaries.Sum(x => x.RemainingLeaves);

            // Return aggregated summary along with individual leave type details
            return new LeaveSummaryDTO
            {
                LeaveType = "All Leave Types", // Label for aggregated summary
                TotalAllocatedLeaves = totalAllocatedLeaves,
                ApprovedLeaves = totalApprovedLeaves,
                PendingLeaves = totalPendingLeaves,
                RejectedLeaves = totalRejectedLeaves,
                RemainingLeaves = totalRemainingLeaves,
                ApprovedCount = totalApprovedCount,
                PendingCount = totalPendingCount,
                RejectedCount = totalRejectedCount,
                LeaveSummaries = leaveSummaries // Include individual summaries
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

            // Add to the database
            await _hrmsContext.LeaveTrackings.AddAsync(leaveTracking);
            await _hrmsContext.SaveChangesAsync(_decodedToken);

            return leaveTracking;
        }
    }
}
