﻿using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.BusinessLogics.Interface;
using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class UserRoleImp : IUserRoles
    {
        private readonly HRMSContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtUtils _jwtUtils;
        public List<string>? dToken;
        private int? _decodedToken;
        public UserRoleImp(HRMSContext context, IHttpContextAccessor httpContextAccessor, IJwtUtils jwtUtils)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _httpContextAccessor = httpContextAccessor;
            
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
        public async Task<bool> deleteUserRole(int id)
        {
            DecodeToken();   
            var result = (from row in _context.UserRolesJs
                          where row.Id == id
                          select row).SingleOrDefault();
            _context.UserRolesJs.Remove(result);
            await _context.SaveChangesAsync(_decodedToken);
            return true;
        }

        public List<UserRolesJ> GetAlluserRole()
        {
            var result = (from row in _context.UserRolesJs
                          where row.IsActive == 1
                          select row).ToList();
            return result;
        }

        public UserRolesJ GetuserRoleById(int id)
        {
            var result = (from row in _context.UserRolesJs
                          where row.Id == id && row.IsActive == 1
                          select row).FirstOrDefault();
           
            return result;
        }

        public async Task<string> InsertuserRoles(UserRolesJ userRolesJ)
        {
            DecodeToken();
            await _context.UserRolesJs.AddAsync(userRolesJ);
            var result = await _context.SaveChangesAsync(_decodedToken);
            if (result != 0)
            {
                return "Successfully assigned role to employee";

            }
            else
            {
                return "failed to assign role to employee";
            }
        }
        public bool SoftDelete(int id, short isActive)
        {
            var res = (from row in _context.UserRolesJs
                       where row.Id == id
                       select row).FirstOrDefault();
            if (res != null)
            {
                res.IsActive = isActive;
                _context.UserRolesJs.Update(res);
                _context.SaveChanges();
                return true;

            }
            return false;
        }
    }
}
