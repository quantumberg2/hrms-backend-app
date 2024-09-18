namespace HRMS_Application.DTO
{
    public class EmployeeShiftAndLeaveStatsDto
    {
        public string ShiftType { get; set; }
        public string ShiftTimeRange { get; set; }
        public int TotalLeaveCount { get; set; }
        public int RemainingLeaveCount { get; set; }
        public double LeavePercentage { get; set; }
    }
}
