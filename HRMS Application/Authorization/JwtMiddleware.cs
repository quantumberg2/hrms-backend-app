using HRMS_Application.BusinessLogics.Interface;
using HRMS_Application.Helpers;
using Microsoft.Extensions.Options;

namespace HRMS_Application.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;

        }

        public async Task Invoke(HttpContext context, IUser UserImp, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateJwtToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = UserImp.GetById(userId.Value);
            }
        }

    }
}
