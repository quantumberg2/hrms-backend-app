using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class OrgChartServiceImp : IOrgChartService
    {
        private readonly HRMSContext _hrmsContext;

        public OrgChartServiceImp(HRMSContext hrmsContext)
        {
            _hrmsContext = hrmsContext;
        }
        public List<OrgChartNode> GetManagersWithEmployees()
        {
            // Fetch managers and their employees from the database
            var result = _hrmsContext.EmployeeCredentials
                .Where(manager => _hrmsContext.EmployeeDetails.Any(emp => emp.ManagerId == manager.Id)) // Ensure manager has employees
                .Select(manager => new OrgChartNode
                {
                    ManagerId = manager.Id,
                    ManagerName = manager.UserName,
                    Designation = _hrmsContext.EmployeeDetails
                .Where(emp => emp.EmployeeCredentialId == manager.Id)   
                .Select(emp => emp.Position.Name)                       
                .FirstOrDefault(),

                    Employees = _hrmsContext.EmployeeDetails
                        .Where(emp => emp.ManagerId == manager.Id)
                        .Select(emp => new EmployeeDetailDto
                        {
                            EmployeeId = emp.EmployeeCredentialId,
                            EmployeeName = emp.FirstName + " " + emp.LastName,
                            Email = emp.Email,
                            Designation = emp.Position.Name


                        }).ToList()
                }).ToList();

            return result;
        }
    }
}
