
using HRMS_Application.Models.Users;
using HRMS_Application.Models;
using HRMS_Application.Authorization;
using HRMS_Application.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using HRMS_Application.DTOs;
using Microsoft.AspNetCore.Server.IIS.Core;
//using System.Web.Http.Results;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace HRMS_Application.BusinessLogics.Implements
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<EmployeeCredential> GetAll();
        EmployeeCredential GetById(int id);
    }
    public class UserService : IUserService
    {
        private readonly HRMSContext _hrmsContext;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public UserService(HRMSContext hrmsContext, IJwtUtils jwtUtils, IOptions<AppSettings> appSettings)
        {
            _hrmsContext = hrmsContext;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            //var user = _CollegeAppContext.Users.SingleOrDefault(x => x.Username == model.Username);

            //var user = (from u in _CollegeAppContext.UserTables
            //            join ur in _CollegeAppContext.UserRoleJs on u.Id equals ur.UserId
            //            join r in _CollegeAppContext.Roles on ur.RoleId equals r.Id
            //            where u.UserName == model.Username && u.Password == model.Password
            //            select new { User = u, UserRole = ur, RoleName = r.RoleName })
            //                  .SingleOrDefault();

            var objUser = (from row in _hrmsContext.EmployeeCredentials
                           where row.UserName == model.Username && row.Password == model.Password
                           
                           select new
                           {
                              
                               row.UserName,
                               row.Id
                           }).FirstOrDefault();
            if (objUser == null)
            {
                // Return forbidden error
                //return new StatusCode(StatusCodes.Status401Unauthorized);
                return null;

            }
            else
            {

                var roles = (from rowUserRolesJ in _hrmsContext.UserRolesJs
                             join rowRoles in _hrmsContext.Roles on rowUserRolesJ.RolesId equals rowRoles.Id
                             where rowUserRolesJ.EmployeeCredentialId == objUser.Id
                             select rowRoles.Name).ToList();

                var user = new UserDto
                {
                    /*Name = objUser.Name,*/
                    UserName = objUser.UserName,
                    UserId = objUser.Id,
                    Roles = roles
                    // Roles = new List<string> { "Admin", "Faculty" }
                };
                // authentication successful so generate jwt token
                var jwtToken = _jwtUtils.GenerateJwtToken(user);
                return new AuthenticateResponse(user, jwtToken, user.Roles);
            }

        }

        public IEnumerable<EmployeeCredential> GetAll()
        {
            var result = (from row in _hrmsContext.EmployeeDetails
                          select row).ToList();
            return (IEnumerable<EmployeeCredential>)result;
            //return _CollegeAppContext.Users;
        }

        public EmployeeCredential GetById(int id)
        {
            var user = (from row in _hrmsContext.EmployeeCredentials
                        where row.Id == id
                        select row).SingleOrDefault();

            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

       
    }
}
