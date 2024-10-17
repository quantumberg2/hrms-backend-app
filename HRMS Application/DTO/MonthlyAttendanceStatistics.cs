namespace HRMS_Application.DTO
{
    public class MonthlyAttendanceStatistics
    {
        public int EmployeecredntialId { get; set; }
        public int TotalWorkingDays { get; set; }  //CONSIDERING Holiday calender and considering sundays remaing days are Total working days for the month
        public TimeSpan? TotalHoursWorked { get; set; } // considering the time range and between timecount and divide by Total workingdays then get toatl hours for workingdays 
        public string? AverageWorkHours { get; set; } // considring thetimein and timeout when the status = present and between calculate the time and divide by the number of days present in a month
        public string? AvgTimein { get; set; }     // Timein/no of timein in a month *100
        public string? AvgTimeouT {  get; set; } // Timeout/no of timeout in amonth * 100
        public int LateInCount { get; set; }   // considering the timerange and shift for the emplyee 09:00 AM - 05:00 PM  considering 9am if the intime is greate than timerange calculate count for the month
        public int EarlyOutCount { get; set; }  // considering the timerange and shift for the emplyee 09:00 AM - 05:00 PM  considering 05pm if the outtime is less than timerange calculate count for the month
        public int AbsentCount { get; set; }  // where the status is Absent calculte the count for the particular month
        public int LeaveTakenCount { get; set; } // considering the status = leave and count that in a month
        public int PenaltyCount { get; set; }  // considering the status = penaltyleave and count that in a month
        public double PresentPercentage { get; set; }  // calculate the pergentage for the presentdays/no of present *100 for the month
        public double AbsentPercentage { get; set; }  // calculate the percentage for the absentdays/no of absent * 100 for the month
        public double LeaveTakenPercentage { get;set; } // considering the status = leave  leavedays/no of leave in a month *100
        public double HolidayPercentage { get;  set; } // calculating the status = holiday holidays/ no of holidays in a month *100
        public double RestDaysPercentage { get; internal set; }
    }
}
