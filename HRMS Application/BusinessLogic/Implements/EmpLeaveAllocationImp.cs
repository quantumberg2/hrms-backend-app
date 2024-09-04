using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Implements
{

    public class EmpLeaveAllocationImp : IEmpLeaveAllocation
    {
        private readonly HRMSContext _hrmsContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtUtils _jwtUtils;
        private List<string>? dToken;
        private int? _decodedToken;
        public EmpLeaveAllocationImp(HRMSContext hrmscontext, IHttpContextAccessor httpContextAccessor, IJwtUtils jwtUtils)
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
        public async Task<bool> DeleteEmployeeLeave(int id)
        {
            DecodeToken();
            var result = (from row in _hrmsContext.EmployeeLeaveAllocations
                          where row.Id == id
                          select row).SingleOrDefault();
            _hrmsContext.EmployeeLeaveAllocations.Remove(result);
            await _hrmsContext.SaveChangesAsync(_decodedToken);
            return true;
        }

        public List<EmployeeLeaveAllocation> GetAllEmpLeave()
        {
            var result = (from row in _hrmsContext.EmployeeLeaveAllocations
                          select row).ToList();
            return result;
        }

        public EmployeeLeaveAllocation GetByEmpLeavebyId(int id)
        {
            var res = (from row in _hrmsContext.EmployeeLeaveAllocations
                       where row.Id == id
                       select row).FirstOrDefault();
            return res;
        }

        public async Task<string> InsertEmployeeLeave(EmployeeLeaveAllocation employeeLeave)
        {
            _hrmsContext.EmployeeLeaveAllocations.Add(employeeLeave);
            var result = await _hrmsContext.SaveChangesAsync(_decodedToken);
            if (result != 0)
            {
                return "new Employeeleave inserted successfully";

            }
            else
            {
                return "failed to insert new data";
            }
        }
    }
}