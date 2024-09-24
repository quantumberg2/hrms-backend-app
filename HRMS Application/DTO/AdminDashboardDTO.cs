namespace HRMS_Application.DTO
{
    public class MonthlyCountDTO
    {
        public int Year { get; set; }
        public string Month { get; set; } // Change this to string to hold month names
        public int JoinedCount { get; set; } // For joined counts
        public int ResignedCount { get; set; } // For resigned counts
    }

    public class ExperienceCountDTO
    {
        public string Years { get; set; }
        public int Count { get; set; }
    }

    public class AdminDashboardDTO
    {
        public int TotalEmployees { get; set; }
        public int NewEmployees { get; set; }
        public List<MonthlyCountDTO> EmployeesJoinedMonthWise { get; set; } // Use your defined DTO
        public List<MonthlyCountDTO> EmployeesResignedMonthWise { get; set; } // Use your defined DTO
        public List<ExperienceCountDTO> ExperienceCounts { get; set; } // Use your defined DTO
    }
}
