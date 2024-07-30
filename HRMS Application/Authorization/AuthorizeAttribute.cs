using HRMS_Application.BusinessLogics.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;

namespace HRMS_Application.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _roles;

        public AuthorizeAttribute(params string[] roles)
        {
            //_roles = roles ?? new Enums.Role[] { };
            _roles = roles;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            var token = context.HttpContext?.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            var userRolesEnum = DecodeToken(token);

            bool authorizationStatus = false;
            if (userRolesEnum == null)
            {
                authorizationStatus = false;
            }
            else
            {
                foreach (var role in userRolesEnum)
                    if (_roles.Contains(role))
                    {
                        authorizationStatus = true;
                    }
            }

            if (!authorizationStatus)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }

        private List<string> DecodeToken(string token)
        {
            if (token == "")
            {
                return null;
            }
            else
            {
                //var user = new JwtSecurityToken(jwtEncodedString: token);
                // var tokentest = new System.IdentityModel.Tokens.JwtSecurityToken(token);

                var user = new JwtSecurityTokenHandler().ReadJwtToken(token);

                var userRoles = user.Claims.Where(c => c.Type == "Roles").Select(c => c.Value).ToList();
                // var userRoleEnum = userRoles.Select(x => (Enums.Role)Enum.Parse(typeof(Role), x)).ToList();
                return userRoles;
            }
        }

      
    }
}
