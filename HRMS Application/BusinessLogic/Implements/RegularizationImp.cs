using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class RegularizationImp : IRegularization
    {
        private readonly HRMSContext _hrmsContext;

        public RegularizationImp(HRMSContext hrmscontext)
        {
            _hrmsContext = hrmscontext;
        }
            public List<LeavePendingDTO> GetPendingRegularization(int employeeCredentialId, string status)
        {
            var pendingRegularization = (from leave in _hrmsContext.LeaveTrackings
                                 join empCred in _hrmsContext.EmployeeCredentials on leave.EmpCredentialId equals empCred.Id
                                 join empDetail in _hrmsContext.EmployeeDetails on empCred.Id equals empDetail.EmployeeCredentialId
                                 join leaveType in _hrmsContext.LeaveTypes on leave.LeaveTypeId equals leaveType.Id
                                 where leaveType.Type == "Regularization" && empCred.Id == employeeCredentialId
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

            return pendingRegularization;
        }

        public async Task<List<LeaveApprovalDTO>> GetRegularizationByStatusAsync(string status, int managerId)
        {
            var regularization = await(from leave in _hrmsContext.LeaveTrackings
                               join emp in _hrmsContext.EmployeeDetails on leave.EmpCredentialId equals emp.EmployeeCredentialId
                               join leaveType in _hrmsContext.LeaveTypes on leave.LeaveTypeId equals leaveType.Id
                               where leave.Status == status
                                     && emp.ManagerId == managerId
                                     && emp.IsActive == 1
                                     && leave.IsActive == 1
                                     && leaveType.Type == "Regularization"
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

            return regularization;
        }
    }
}
