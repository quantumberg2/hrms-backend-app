
using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.BusinessLogics.Interface;
using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class EmployeeAttendanceImp : IEmployeeAttendance
    {
        private readonly HRMSContext _hrmsContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtUtils _jwtUtils;
        private List<string>? dToken;
        private int? _decodedToken;
        public EmployeeAttendanceImp(HRMSContext hrmscontext, IHttpContextAccessor httpContextAccessor, IJwtUtils jwtUtils)
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
                        dToken = userDetails.UserRolesJs.Select(ur => ur.Roles.Name).ToList(); // Assuming you want role names
                    }
                    else
                    {
                        // Handle the case where the user is not found in the database
                        dToken = null;
                    }
                }
            }
        }
        public async Task<bool> DeleteEmployeeAttendance(int id)
        {
            DecodeToken();
            var result = (from row in _hrmsContext.Attendences
                          where row.Id == id
                          select row).SingleOrDefault();
            _hrmsContext.Attendences.Remove(result);
            await _hrmsContext.SaveChangesAsync(_decodedToken);
            return true;
        }

        public List<Attendence> GetAllEmpAttendence()
        {
            var result = (from row in _hrmsContext.Attendences
                          select row).ToList();
            return result;
        }

        public Attendence GetById(int id)
        {
            var res = (from row in _hrmsContext.Attendences
                       where row.Id == id
                       select row).FirstOrDefault();
            return res;
        }

        public async Task<string> InsertEmployeeAttendence(Attendence employeeAttendence)
        {
            DecodeToken();
            _hrmsContext.Attendences.Add(employeeAttendence);
            var result = await _hrmsContext.SaveChangesAsync(_decodedToken);
            if (result != 0)
            {
                return "new Employee inserted successfully";

            }
            else
            {
                return "failed to insert new data";
            }
        }
        public async Task<Attendence> UpdateEmployeeAttendence(int id, DateTime? Timein, DateTime? Timeout, string? Remark, int empcredentialId)
        {
            var result = _hrmsContext.Attendences.SingleOrDefault(p => p.Id == id);
            if (result == null)
            {
                // Handle the case where the user with the specified id doesn't exist
                return null;
            }
            /* result.TimeIn = Timein;
             result.TimeOut = Timeout;
             result.Remarks = Remark;*/
            result.EmpCredentialId = empcredentialId;
            _hrmsContext.Attendences.Update(result);
            await _hrmsContext.SaveChangesAsync(_decodedToken);
            return result;
        }
    }
}
