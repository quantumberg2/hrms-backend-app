namespace HRMS_Application.DTO
{
    public class LeavePendingDTO
    {
        public int employeecredentialId { get; set; }
        public string Name { get; set; }
        public string LeaveType { get; set; }
        public string managername { get; set; }
        public string? Reason { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? Applieddate { get; set; }
        public int NoofDays { get; set; }
    }
}
