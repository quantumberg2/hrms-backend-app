namespace HRMS_Application.DTO
{
    public class EmployeeDetailsDTO
    {
        public int? DeptId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int? PositionId { get; set; }
        public int? EmployeeCredentialId { get; set; }
        public string EmployeeNumber { get; set; }
        public string Email { get; set; }
        public int? RequestCompanyId { get; set; }
        public short? IsActive { get; set; }
        public int? ManagerId { get; set; }
        public string NickName { get; set; }
        public string Extension { get; set; }
        public string MobileNumber { get; set; }
        public string NumberOfYearsExperience { get; set; }
        public IFormFile? ImageUrl { get; set; }
    }
}
