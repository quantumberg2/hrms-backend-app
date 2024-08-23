
using HRMS_Application.Models.Users;
using HRMS_Application.Models;
using HRMS_Application.Authorization;
using HRMS_Application.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using HRMS_Application.DTOs;
using Microsoft.AspNetCore.Server.IIS.Core;
using System.Net;
using Microsoft.AspNetCore.Http;
using HRMS_Application.DTO;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace HRMS_Application.BusinessLogics.Implements
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<EmployeeCredential> GetAll();
        EmployeeCredential GetById(int id);
        AuthenticateResponse SelectCompany(SelectCompanyRequest model, int Userid);

    }
    public class UserService : IUserService
    {
        private readonly HRMSContext _hrmsContext;
        private readonly IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public UserService(HRMSContext hrmsContext, IJwtUtils jwtUtils, IOptions<AppSettings> appSettings)
        {
            _hrmsContext = hrmsContext;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        /* public AuthenticateResponse Authenticate(AuthenticateRequest model)
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
                                row.Id,
                                row.Email,
                                row.RequestedCompanyId,

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
                     *//*Name = objUser.Name,*//*
                     UserName = objUser.UserName,
                     UserId = objUser.Id,
                     Email = objUser.Email,
                     RequestedCompanyId = objUser.RequestedCompanyId,
                     Roles = roles
                     // Roles = new List<string> { "Admin", "Faculty" }
                 };
                 // authentication successful so generate jwt token
                 var jwtToken = _jwtUtils.GenerateJwtToken(user);
                 return new AuthenticateResponse(user, jwtToken, user.Roles);
             }

         }*/
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var userCompanies = (from empCred in _hrmsContext.EmployeeCredentials
                                 join reqComp in _hrmsContext.RequestedCompanyForms
                                 on empCred.RequestedCompanyId equals reqComp.Id
                                 where empCred.Email == model.Username
                                       && empCred.Password == model.Password
                                 select new
                                 {
                                     empCred.UserName,
                                     empCred.Id,
                                     empCred.Email,
                                     empCred.RequestedCompanyId,
                                 }).ToList();

            if (!userCompanies.Any())
            {
                // Return forbidden error
                return null;
            }
            else if (userCompanies.Count > 1)
            {
                var objUser = userCompanies.First();

                // Get roles and token for the first user
                var roles = (from rowUserRolesJ in _hrmsContext.UserRolesJs
                             join rowRoles in _hrmsContext.Roles on rowUserRolesJ.RolesId equals rowRoles.Id
                             where rowUserRolesJ.EmployeeCredentialId == objUser.Id
                             select rowRoles.Name).ToList();

                var user = new UserDto
                {
                    UserName = objUser.UserName,
                    UserId = objUser.Id,
                    Email = objUser.Email,
                    RequestedCompanyId = objUser.RequestedCompanyId,
                    Roles = roles,
                };
                

                // authentication successful so generate jwt token
                var jwtToken = _jwtUtils.GenerateJwtToken(user);

                // Return the response with both roles and company IDs
                var companyIds = userCompanies.Select(u => u.RequestedCompanyId).Where(id => id.HasValue).Select(id => id.Value).ToList();
                return new AuthenticateResponse(user, jwtToken, roles, companyIds);
            }
            else
            {
                var objUser = userCompanies.First();

                var roles = (from rowUserRolesJ in _hrmsContext.UserRolesJs
                             join rowRoles in _hrmsContext.Roles on rowUserRolesJ.RolesId equals rowRoles.Id
                             where rowUserRolesJ.EmployeeCredentialId == objUser.Id
                             select rowRoles.Name).ToList();

                var user = new UserDto
                {
                    UserName = objUser.UserName,
                    UserId = objUser.Id,
                    Email = objUser.Email,
                    RequestedCompanyId = objUser.RequestedCompanyId,
                    Roles = roles
                };

                // authentication successful so generate jwt token
                var jwtToken = _jwtUtils.GenerateJwtToken(user);
                return new AuthenticateResponse(user, jwtToken, user.Roles, new List<int> { objUser.RequestedCompanyId.Value });
            }
        }
        public AuthenticateResponse SelectCompany(SelectCompanyRequest model, int Userid)
        {

            var empCred = _hrmsContext.EmployeeCredentials
                           .FirstOrDefault(ec => ec.RequestedCompanyId == model.CompanyId);

            if (empCred == null)
            {
                return null;
            }

            var roles = (from rowUserRolesJ in _hrmsContext.UserRolesJs
                         join rowRoles in _hrmsContext.Roles on rowUserRolesJ.RolesId equals rowRoles.Id
                         where rowUserRolesJ.EmployeeCredentialId == empCred.Id
                         select rowRoles.Name).ToList();

            var user = new UserDto
            {
                UserName = empCred.UserName,
                UserId = empCred.Id,
                Email = empCred.Email,
                RequestedCompanyId = empCred.RequestedCompanyId,
                Roles = roles
            };

            // authentication successful so generate jwt token
            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            return new AuthenticateResponse(user, jwtToken, user.Roles, new List<int> { empCred.RequestedCompanyId.Value });
        }


        public IEnumerable<EmployeeCredential> GetAll()
        {
            var result = (from row in _hrmsContext.EmployeeDetails
                          select row).ToList();
            return (IEnumerable<EmployeeCredential>)result;
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
