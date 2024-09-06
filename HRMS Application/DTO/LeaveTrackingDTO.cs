namespace HRMS_Application.DTO
{
    public class LeaveTrackingDTO
    {
        public int Id { get; set; }
        public int EmpCredentialId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Applied { get; set; }
        public string Files { get; set; }
        public int LeaveTypeId { get; set; }
        public string Session { get; set; }
        public string Contact { get; set; }
        public string ReasonForLeave { get; set; }
    }
}
