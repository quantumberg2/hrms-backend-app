using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using HRMS_Application.Middleware.Exceptions;
using System.Xml.Linq;
using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogics.Interface;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class EmpCredentialImp : IEmpCredential
    {
        private readonly HRMSContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IJwtUtils _jwtUtils;
        private readonly IUser _user;
        private List<string>? dToken;
        private int? _decodedToken;
        public EmpCredentialImp(HRMSContext context, IHttpContextAccessor httpContextAccessor, IJwtUtils jwtUtils)
        {
            _context = context;
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
                    var userDetails = _context.EmployeeCredentials.FirstOrDefault(e => e.Id == userId.Value);
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
        public async Task<bool> DeleteEmployeeCredential(int id)
        {
            var result = (from row in _context.EmployeeCredentials
                          where row.Id == id
                          select row).SingleOrDefault();
            _context.EmployeeCredentials.Remove(result);
            await _context.SaveChangesAsync(_decodedToken);
            return true;
            
        }

        public List<EmployeeCredential> GetAllEmpCredential()
        {
            var result = (from row in _context.EmployeeCredentials
                          select row).ToList();
            return result;
            
        }

        public EmployeeCredential GetById(int id)
        {
            var result = (from row in _context.EmployeeCredentials
                          where row.Id == id
                          select row).SingleOrDefault();
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new NotFoundException($"Employee Credential Id '{id}' is not found");
            }
        }

        public async Task<string> InsertEmployeeCredential(EmployeeCredential employeeCredential)
        {
            _context.EmployeeCredentials.Add(employeeCredential);
            var result = await _context.SaveChangesAsync(_decodedToken);
            if (result != 0)
            {
                return "New Employee Credentials inserted successfully";

            }
            else
            {
                throw new DatabaseOperationException("Failed to insert Employee credential data");
            }
        }

        

        public async Task<EmployeeCredential> UpdateEmployeeCredentials(int id, string? username, string? password, short? status, int? requestedCompanyId)
        {
            var result = _context.EmployeeCredentials.SingleOrDefault(p => p.Id == id);
            if (result != null)
            {
                // Handle the case where the user with the specified id doesn't exist
                result.UserName = username;
                result.Password = password;
                result.Status = status;
                result.RequestedCompanyId = requestedCompanyId;
                _context.EmployeeCredentials.Update(result);
                await _context.SaveChangesAsync(_decodedToken);
                return result;
            }
            else
            {
                throw new NotFoundException($"Employee Credential  id {id} is not found to update");
            }

        }
    }
}
