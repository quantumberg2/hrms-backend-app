
namespace HRMS_Application.DTO
{
    public class EmployeeShiftAndLeaveStatsDto
    {
        public string? ShiftType { get; set; }
        public string? ShiftTimeRange { get; set; }
        public int? TotalLeaveCount { get; set; }
        public int? RemainingLeaveCount { get; set; }
        public double? LeavePercentage { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int? MonthlyPresentDays { get; internal set; }
        public int? TotalWorkingDays { get; internal set; }
        public double? AttendancePercentage { get; set; }  // New property added for attendance percentage
        /* public List<AttendanceDTO> AttendanceDetails { get; set; } */

    }
}
