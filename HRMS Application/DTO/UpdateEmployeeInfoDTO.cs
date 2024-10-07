namespace HRMS_Application.DTO
{
    public class UpdateEmployeeInfoDTO
    {
        public int EmployeeCredentialId { get; set; }
        public string? EmployeeName { get; set; }
        public string? NickName { get; set; }
        public string? EmailAddress { get; set; }
        public string? EmpLoginName { get; set; }
        public string? MobileNumber { get; set; }
        public string? Extension { get; set; }
        public string? gender { get; set; }
        public IFormFile? imageUrl { get; set; }
    }
}
