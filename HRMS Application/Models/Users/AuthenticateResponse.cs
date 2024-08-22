
using HRMS_Application.DTOs;

public class AuthenticateResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int? CompanyRequestId { get; set; }
    public List<int> CompanyIds { get; set; }
    public List<string> Roles { get; set; }
    public string Token { get; set; }

    public AuthenticateResponse(UserDto user, string token, List<string> roles, List<int> companyIds)
    {
        Id = user.UserId;
        Username = user.UserName;
        Email = user.Email;
        Roles = roles;
        Token = token;
        CompanyIds = companyIds;
    }

    public AuthenticateResponse(List<int> companyIds)
    {
        CompanyIds = companyIds;
    }
}
