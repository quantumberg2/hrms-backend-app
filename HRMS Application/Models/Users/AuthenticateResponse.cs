using HRMS_Application.DTOs;
using System.Data;

namespace HRMS_Application.Models.Users
{
    public class AuthenticateResponse
    {
 

        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? CompanyRequestId { get; set; }
        public List<string> CompanyNames { get; set; } // Add this field to hold company names

        // public List<string> Roles { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
        public AuthenticateResponse(UserDto user, string token, List<string> roles)
        {
            Id = user.UserId;
            /*Name = user.Name;*/
            Username = user.UserName;
            Email = user.Email;
            CompanyRequestId = user.RequestedCompanyId;
            //CompanyNames = user.CompanyNames;
            Roles = roles;
            Token = token;
        }
    }
  
}
