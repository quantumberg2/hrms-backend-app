namespace HRMS_Application.DTO
{
    public class EmployeeLeaveAllocationRequest
    {
        public int? Year { get; set; }
        public int? EmpCredentialId { get; set; } // For single credential ID
        public int? NumberOfLeaves { get; set; }
        public int? RemainingLeave { get; set; }
        public int? LeaveType { get; set; }
    }
}
