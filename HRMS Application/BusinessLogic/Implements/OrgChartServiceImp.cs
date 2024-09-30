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
        public async Task<OrgChartNode> GetOrganizationChartAsync()
        {
            var employees = await _hrmsContext.EmployeeDetails
                            .Where(e => e.IsActive == 1)
                            .ToListAsync();

            var positions = await _hrmsContext.Positions
                            .Where(p => p.IsActive == 1)
                            .ToListAsync();

            var employeeLookup = new Dictionary<int, EmployeeDetail>();

            foreach (var employee in employees)
            {
                if (!employee.EmployeeCredentialId.HasValue || employeeLookup.ContainsKey(employee.EmployeeCredentialId.Value))
                {
                    continue; 
                }

                employeeLookup[employee.EmployeeCredentialId.Value] = employee;
            }
            var positionLookup = positions.ToDictionary(p => p.Id, p => p.Name);


            var ceo = employeeLookup.Values.FirstOrDefault(emp => emp.ManagerId == 0);
            if (ceo == null)
            {
                throw new Exception("No CEO found with ManagerId = 0");
            }

            // Recursively build the hierarchy
            return BuildNode(ceo, employeeLookup, positionLookup);
        }

        private OrgChartNode BuildNode( EmployeeDetail employee, Dictionary<int, EmployeeDetail> employeeLookup, Dictionary<int, string> positionLookup)
        {
            var positionName = employee.PositionId.HasValue && positionLookup.ContainsKey(employee.PositionId.Value)
           ? positionLookup[employee.PositionId.Value]
           : "Unknown Position";
            var node = new OrgChartNode
            {
                FullName = $"{employee.FirstName} {employee.LastName}",
                PositionName = positionName,
                Email = employee.Email,
                ImageURl = employee.ImageUrl,
                Subordinates = new List<OrgChartNode>() 
            };

            // Find all subordinates (employees whose ManagerId matches the current employee's EmployeeCredentialId)
            var subordinates = employeeLookup.Values
                .Where(e => e.ManagerId == employee.EmployeeCredentialId).ToList();

            // Recursively build the hierarchy for all subordinates
            foreach (var subordinate in subordinates)
            {
                node.Subordinates.Add(BuildNode(subordinate, employeeLookup, positionLookup));
            }

            return node;
        }
    }
}
