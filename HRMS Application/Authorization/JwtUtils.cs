using HRMS_Application.DTOs;
using HRMS_Application.Entities;
using HRMS_Application.Helpers;
using HRMS_Application.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HRMS_Application.Authorization
{
    public interface IJwtUtils
    {
        //public string GenerateJwtToken(User user);
        public string GenerateJwtToken(UserDto user);
        public int? ValidateJwtToken(string token);
    }
    public class JwtUtils : IJwtUtils
    {
        private readonly AppSettings _appSettings;

        public JwtUtils(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public string GenerateJwtToken(UserDto user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var claims = new List<Claim>
            {
                   new Claim("UserId", user.UserId.ToString().Trim()),
                    new Claim("UserName", user.UserName.ToString().Trim()),
                    new Claim ("Email",user.Email.ToString().Trim()),
                    new Claim("CompanyId", user.RequestedCompanyId.ToString().Trim()),
                    //new Claim ("CompanyNames", user.CompanyNames.ToString().Trim()),
                    //new Claim("Name", user.Name.ToString().Trim())
            };

            claims.AddRange(user.Roles.Select(role => new Claim("Roles", role)));




            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.AsEnumerable()),
                //Subject = new ClaimsIdentity(new[]
                //{
                //    new Claim("UserId", user.UserId.ToString().Trim()),
                //    new Claim("UserName", user.UserName.ToString().Trim())
                //}),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public int? ValidateJwtToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "UserId").Value);

                // return user id from JWT token if validation successful
                return userId;
            }
            catch
            {
                // return null if validation fails
                return null;
            }

        }
    }
}
