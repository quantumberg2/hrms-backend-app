using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using System.Globalization;
using HRMS_Application.Middleware.Exceptions;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class AdmindashboardImp : IAdminDashboard
    {
        private readonly HRMSContext _hrmsContext;

        public AdmindashboardImp(HRMSContext hrmsContext)
        {
            _hrmsContext = hrmsContext ?? throw new ArgumentNullException(nameof(hrmsContext));
        }

        public async Task<AdminDashboardDTO> GetAdminDashboardAsync(int companyId)
        {
            try
            {
                var currentDate = DateTime.Now;
                var startOfYear = new DateTime(currentDate.Year - 1, 1, 1); 
                var endOfYear = new DateTime(currentDate.Year + 1, 12, 31); 

                var totalEmployees = await _hrmsContext.EmployeeDetails
                    .CountAsync(e => e.IsActive == 1 && e.RequestCompanyId == companyId);

                if (totalEmployees == 0)
                {
                    throw new NotFoundException("No employees found for the company.");
                }

                var newEmployees = await _hrmsContext.EmpPersonalInfos
                    .Join(_hrmsContext.EmployeeCredentials,
                        empInfo => empInfo.EmployeeCredentialId,
                        cred => cred.Id,
                        (empInfo, cred) => new { empInfo, cred }) 
                    .Where(e => e.cred.RequestedCompanyId == companyId &&
                                e.empInfo.DateOfJoining.HasValue &&
                                e.empInfo.DateOfJoining.Value >= startOfYear &&
                                e.empInfo.DateOfJoining.Value <= endOfYear)
                    .CountAsync();

                var employeesJoinedMonthWise = await _hrmsContext.EmpPersonalInfos
                    .Join(_hrmsContext.EmployeeCredentials,
                        empInfo => empInfo.EmployeeCredentialId,
                        cred => cred.Id,
                        (empInfo, cred) => new { empInfo, cred })
                    .Where(e => e.cred.RequestedCompanyId == companyId &&
                                e.empInfo.DateOfJoining.HasValue &&
                                e.empInfo.DateOfJoining.Value >= startOfYear &&
                                e.empInfo.DateOfJoining.Value <= endOfYear)
                    .GroupBy(e => new { e.empInfo.DateOfJoining.Value.Year, e.empInfo.DateOfJoining.Value.Month })
                    .Select(g => new MonthlyCountDTO
                    {
                        Year = g.Key.Year,
                        Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(g.Key.Month),
                        JoinedCount = g.Count()
                    })
                    .ToListAsync();

                var employeesResignedMonthWise = await _hrmsContext.EmployeeCredentials
                    .Where(e => e.IsActive == 0 && e.ResignedDate.HasValue && e.ResignedDate.Value >= startOfYear && e.ResignedDate.Value <= endOfYear && e.RequestedCompanyId == companyId)
                    .GroupBy(e => new { e.ResignedDate.Value.Year, e.ResignedDate.Value.Month })
                    .Select(g => new MonthlyCountDTO
                    {
                        Year = g.Key.Year,
                        Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(g.Key.Month),
                        ResignedCount = g.Count()
                    })
                    .ToListAsync();

                var experienceCounts = await (from e in _hrmsContext.EmployeeDetails
                                              join p in _hrmsContext.EmpPersonalInfos
                                              on e.EmployeeCredentialId equals p.EmployeeCredentialId
                                              where e.IsActive == 1 && e.RequestCompanyId == companyId && !string.IsNullOrEmpty(e.NumberOfYearsExperience)
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

                var dashboardData = new AdminDashboardDTO
                {
                    TotalEmployees = totalEmployees,
                    NewEmployees = newEmployees,
                    EmployeesJoinedMonthWise = employeesJoinedMonthWise,
                    EmployeesResignedMonthWise = employeesResignedMonthWise,
                    ExperienceCounts = experienceGroups
                };

                return dashboardData;
            }
            catch (DbUpdateException dbEx) 
            {
                throw new DatabaseOperationException($"Database operation failed: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                throw new BadRequestException($"An error occurred while generating the dashboard: {ex.Message}");
            }
        }
    }
}
