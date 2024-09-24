using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class AdmindashboardImp : IAdminDashboard
    {
        private readonly HRMSContext _hrmsContext;

        public AdmindashboardImp(HRMSContext hrmsContext)
        {
            _hrmsContext = hrmsContext ?? throw new ArgumentNullException(nameof(hrmsContext));
        }

        public async Task<AdminDashboardDTO> GetAdminDashboardAsync()
        {
            try
            {
                var currentDate = DateTime.Now;
                var startOfYear = new DateTime(currentDate.Year - 1, 1, 1); // Start from January 1 of the previous year
                var endOfYear = new DateTime(currentDate.Year + 1, 12, 31); // End by December 31 of the next year

                // Total employees (active employees)
                var totalEmployees = await _hrmsContext.EmployeeDetails
                    .CountAsync(e => e.IsActive == 1);

                // New employees (who joined in the last year)
                var newEmployees = await _hrmsContext.EmpPersonalInfos
                    .CountAsync(e => e.DateOfJoining.HasValue && e.DateOfJoining.Value >= startOfYear && e.DateOfJoining.Value <= endOfYear);

                var employeesJoinedMonthWise = await _hrmsContext.EmpPersonalInfos
      .Where(e => e.DateOfJoining.HasValue && e.DateOfJoining.Value >= startOfYear && e.DateOfJoining.Value <= endOfYear)
      .GroupBy(e => new { e.DateOfJoining.Value.Year, e.DateOfJoining.Value.Month })
      .Select(g => new MonthlyCountDTO
      {
          Year = g.Key.Year,
          Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(g.Key.Month), // Get abbreviated month name
          JoinedCount = g.Count()
      })
      .ToListAsync();

                // Employees resigned in the specified range, grouped by month and year
                var employeesResignedMonthWise = await _hrmsContext.EmployeeCredentials
     .Where(e => e.IsActive == 0 && e.ResignedDate.HasValue && e.ResignedDate.Value >= startOfYear && e.ResignedDate.Value <= endOfYear)
     .GroupBy(e => new { e.ResignedDate.Value.Year, e.ResignedDate.Value.Month })
     .Select(g => new MonthlyCountDTO
     {
         Year = g.Key.Year,
         Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(g.Key.Month), // Get abbreviated month name
         ResignedCount = g.Count()
     })
     .ToListAsync();

                // Total years of experience for active employees
                var experienceCounts = await _hrmsContext.EmployeeDetails
                    .Where(e => e.IsActive == 1 && !string.IsNullOrEmpty(e.NumberOfYearsExperience))
                    .ToListAsync();

                // Calculate total experience by grouping and counting
                var experienceSummary = experienceCounts
                    .GroupBy(e => e.NumberOfYearsExperience)
                    .Select(g => new ExperienceCountDTO
                    {
                        Years = g.Key,
                        Count = g.Count()
                    })
                    .ToList();

                // Total experience calculation
                var totalExperienceSum = experienceCounts.Sum(e =>
                    int.TryParse(e.NumberOfYearsExperience, out int years) ? years : 0);

                // Prepare the dashboard DTO
                var dashboardData = new AdminDashboardDTO
                {
                    TotalEmployees = totalEmployees,
                    NewEmployees = newEmployees,
                    EmployeesJoinedMonthWise = employeesJoinedMonthWise,
                    EmployeesResignedMonthWise = employeesResignedMonthWise,
                    ExperienceCounts = experienceSummary
                };

                return dashboardData;
            }
            catch (Exception ex)
            {
                // Log exception if necessary
                throw; // Rethrow or handle accordingly
            }
        }


    }
}
