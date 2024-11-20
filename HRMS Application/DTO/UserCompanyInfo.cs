namespace HRMS_Application.DTO
{
    public class UserCompanyInfo
    {
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public int? RequestedCompanyId { get; set; } // List of company IDs
        //public List<string> CompanyNames { get; set; } // List of company names

        // public string Password { get; set; }
        public List<string> Roles { get; set; }
        public string JwtToken { get;  set; }
    }
}
