namespace HRMS_Application.DTO
{
    internal class LeaveTrackingEmployeeDTO
    {
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}