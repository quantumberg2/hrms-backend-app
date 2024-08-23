using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.BusinessLogics.Interface;
using HRMS_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class RolesImp : IRoles
    {
        private HRMSContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtUtils _jwtUtils;
        private List<string>? dToken;
        private int? _decodedToken;
        public RolesImp(HRMSContext context, IHttpContextAccessor httpContextAccessor, IJwtUtils jwtUtils)
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
        public async Task<bool> deleteRole(int id)
        {
            DecodeToken();
            var result = (from row in _context.Roles
                          where row.Id == id
                          select row).SingleOrDefault();
            _context.Roles.Remove(result);
            await _context.SaveChangesAsync(_decodedToken);
            return true;
        }

        public List<Role> GetAllRoles()
        {
            var result = (from row in _context.Roles
                          select row).ToList();
            return result;
        }

        public Role GetRolesById(int id)
        {
            var result = (from row in _context.Roles
                          where row.Id == id
                          select row).FirstOrDefault();
           
            return result;
        }

        public async Task<string> InsertRole(Role role)
        {
           await _context.Roles.AddAsync(role);
            var result = await _context.SaveChangesAsync(_decodedToken);
            if (result != 0)
            {
                return "new Department inserted successfully";

            }
            else
            {
                return "failed to insert new data";
            }
        }
    }
}
