//using Global_clg_App.BusinessLogics.Interface;
//using Global_clg_App.Helpers;
//using Microsoft.Extensions.Options;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Text;

//namespace Global_clg_App.Helpers
//{
//    public class JwtMiddleware
//    {
//        private readonly RequestDelegate _next;
//        private readonly AppSettings _appSettings;

//        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
//        {
//            _next = next;
//            _appSettings = appSettings.Value;
//        }

//        public async Task Invoke(HttpContext context, IUser UserImp)
//        {
//            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

//            if (token != null)
//                attachUserToContext(context, UserImp, token);

//            await _next(context);
//        }

//        private void attachUserToContext(HttpContext context, IUser UserImp, string token)
//        {
//            try
//            {
//                var tokenHandler = new JwtSecurityTokenHandler();
//                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
//                tokenHandler.ValidateToken(token, new TokenValidationParameters
//                {
//                    ValidateIssuerSigningKey = true,
//                    IssuerSigningKey = new SymmetricSecurityKey(key),
//                    ValidateIssuer = false,
//                    ValidateAudience = false,
//                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
//                    ClockSkew = TimeSpan.Zero
//                }, out SecurityToken validatedToken);

//                var jwtToken = (JwtSecurityToken)validatedToken;
//                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

//                // attach user to context on successful jwt validation
//                context.Items["User"] = UserImp.GetById(userId);
//            }
//            catch
//            {
//                // do nothing if jwt validation fails
//                // user is not attached to context so request won't have access to secure routes
//            }
//        }
//    }
//}
