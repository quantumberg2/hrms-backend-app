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
                    Employees = _hrmsContext.EmployeeDetails
                        .Where(emp => emp.ManagerId == manager.Id)
                        .Select(emp => new EmployeeDetailDto
                        {
                            EmployeeId = emp.Id,
                            EmployeeName = emp.FirstName + " " + emp.LastName,
                            Email = emp.Email,
                            PositionId = emp.PositionId,
                            Department = emp.DeptId // Assuming Department entity has a DeptName field
                        }).ToList()
                }).ToList();

            return result;
        }
    }
}
