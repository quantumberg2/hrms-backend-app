using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
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

        public async Task<AdminDashboardDTO> GetAdminDashboardAsync(int comapnyId)
        {
            try
            {
                var currentDate = DateTime.Now;
                var startOfYear = new DateTime(currentDate.Year - 1, 1, 1); // Start from January 1 of the previous year
                var endOfYear = new DateTime(currentDate.Year + 1, 12, 31); // End by December 31 of the next year

                // Total employees (active employees)
                var totalEmployees = await _hrmsContext.EmployeeDetails
                    .CountAsync(e => e.IsActive == 1 && e.RequestCompanyId == comapnyId);

                // New employees (who joined in the last year) for the specific company
                var newEmployees = await _hrmsContext.EmpPersonalInfos
                    .Join(_hrmsContext.EmployeeCredentials,
                        empInfo => empInfo.EmployeeCredentialId,
                        cred => cred.Id,
                        (empInfo, cred) => new { empInfo, cred }) // Joining EmpPersonalInfos with EmployeeCredentials
                    .Where(e => e.cred.RequestedCompanyId == comapnyId &&
                                e.empInfo.DateOfJoining.HasValue &&
                                e.empInfo.DateOfJoining.Value >= startOfYear &&
                                e.empInfo.DateOfJoining.Value <= endOfYear)
                    .CountAsync();

                // Employees joined month-wise for the specific company
                var employeesJoinedMonthWise = await _hrmsContext.EmpPersonalInfos
                    .Join(_hrmsContext.EmployeeCredentials,
                        empInfo => empInfo.EmployeeCredentialId,
                        cred => cred.Id,
                        (empInfo, cred) => new { empInfo, cred }) // Joining EmpPersonalInfos with EmployeeCredentials
                    .Where(e => e.cred.RequestedCompanyId == comapnyId &&
                                e.empInfo.DateOfJoining.HasValue &&
                                e.empInfo.DateOfJoining.Value >= startOfYear &&
                                e.empInfo.DateOfJoining.Value <= endOfYear)
                    .GroupBy(e => new { e.empInfo.DateOfJoining.Value.Year, e.empInfo.DateOfJoining.Value.Month })
                    .Select(g => new MonthlyCountDTO
                    {
                        Year = g.Key.Year,
                        Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(g.Key.Month), // Get abbreviated month name
                        JoinedCount = g.Count()
                    })
                    .ToListAsync();


                // Employees resigned in the specified range, grouped by month and year
                var employeesResignedMonthWise = await _hrmsContext.EmployeeCredentials
     .Where(e => e.IsActive == 0 && e.ResignedDate.HasValue && e.ResignedDate.Value >= startOfYear && e.ResignedDate.Value <= endOfYear && e.RequestedCompanyId == comapnyId)
     .GroupBy(e => new { e.ResignedDate.Value.Year, e.ResignedDate.Value.Month })
     .Select(g => new MonthlyCountDTO
     {
         Year = g.Key.Year,
         Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(g.Key.Month), // Get abbreviated month name
         ResignedCount = g.Count()
     })
     .ToListAsync();
                var experienceCounts = await (from e in _hrmsContext.EmployeeDetails
                                              join p in _hrmsContext.EmpPersonalInfos
                                              on e.EmployeeCredentialId equals p.EmployeeCredentialId
                                              where e.IsActive == 1 && e.RequestCompanyId == comapnyId &&  !string.IsNullOrEmpty(e.NumberOfYearsExperience)
                                              select new
                                              {
                                                  EmployeeDetail = e,
                                                  CurrentCompanyJoiningDate = p.DateOfJoining
                                              })
                               .ToListAsync();

                
              
                var experienceGroups = experienceCounts.Select(e =>
                {
                    double previousExperience = double.TryParse(e.EmployeeDetail.NumberOfYearsExperience, out double years) ? years : 0;

                    DateTime joiningDate = e.CurrentCompanyJoiningDate ?? currentDate;

                    double currentExperience = (currentDate - joiningDate).TotalDays / 365;

                    double totalExperience = previousExperience + currentExperience;

                    return Math.Round(totalExperience, 1);
                })
                .GroupBy(experience => experience) 
                .Select(g => new ExperienceCountDTO
                {
                    Years = g.Key.ToString(), 
                    Count = g.Count()         
                })
                .ToList();

                // Prepare the dashboard DTO
                var dashboardData = new AdminDashboardDTO
                {
                    TotalEmployees = totalEmployees,
                    NewEmployees = newEmployees,
                    EmployeesJoinedMonthWise = employeesJoinedMonthWise,
                    EmployeesResignedMonthWise = employeesResignedMonthWise,
                    ExperienceCounts = experienceGroups // Set the calculated experience groups
                };

                return dashboardData;


            }
            catch (Exception ex)
            {
                throw; 
            }
        }


    }
}
