namespace HRMS_Application.DTO
{
    public class EmployeeDto
    {
        public string EmployeeNumber { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int? DeptId { get; set; }
        public int? PositionId { get; set; }
    }
}
