using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Models;
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
            var result = _hrmsContext.LeaveTrackings.ToList();
            return result;
        }

        public async Task<LeaveTracking> GetByIdAsync(int id)
        {
            var res = (from row in _hrmsContext.LeaveTrackings
                       where row.Id == id
                       select row).FirstOrDefault();
            return res;
        }

        public async Task<LeaveTracking> CreateAsync(LeaveTracking leaveTracking, int empCredentialId)
        {
            DecodeToken();
            leaveTracking.EmpCredentialId = empCredentialId;

            // Add to the database
            _hrmsContext.LeaveTrackings.Add(leaveTracking);
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

    }
}
