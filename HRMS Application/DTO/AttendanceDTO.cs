namespace HRMS_Application.DTO
{
    public class AttendanceDTO
    {
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public string Status { get; set; }
        public string Shift { get; set; }
        public DateTime Date { get; set; }
    }
}
