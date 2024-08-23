namespace HRMS_Application.DTOs
{
    public class UserDto
    {
       // public string Name { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public int? RequestedCompanyId { get; set; } // List of company IDs
        public List<int> CompanyIds { get; set; }

        //public List<string> CompanyNames { get; set; } // List of company names

        // public string Password { get; set; }
        public List<string> Roles { get; set; }
    }
}
