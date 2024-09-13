using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class OrgChartServiceImp : IOrgChartService
    {
        private readonly HRMSContext _hrmsContext;

        public OrgChartServiceImp(HRMSContext hrmsContext)
        {
            _hrmsContext = hrmsContext;
        }
        public async Task<List<OrgChartNode>> GetOrgChartAsync()
        {
            var employees = _hrmsContext.EmployeeDetails
                .Where(e => e.IsActive == 1) 
                .Select(e => new OrgChartNode
                {
                    Id = e.Id,
                    Name = $"{e.FirstName} {e.MiddleName} {e.LastName}",
                    ManagerId = e.ManagerId,
                    Email = e.Email,
                    PositionId = e.PositionId,
                    EmployeeCredentialId = e.EmployeeCredentialId
                })
                .ToList();


            var orgChart = BuildOrgChartHierarchy(employees);


            if (orgChart.Count == 0)
            {
                return await Task.FromResult(new List<OrgChartNode>());
            }

            return await Task.FromResult(orgChart);
        }

        private List<OrgChartNode> BuildOrgChartHierarchy(List<OrgChartNode> employees)
        {
            var lookup = employees.ToLookup(e => e.ManagerId);

            var topLevelNodes = new List<OrgChartNode>();

            foreach (var emp in employees)
            {
                emp.Children = lookup[emp.Id].ToList();

                
                if (emp.ManagerId == null)
                {
                    topLevelNodes.Add(emp);
                }
            }
            foreach (var node in topLevelNodes)
            {
                SortChildren(node);
            }

            return topLevelNodes;
        }

        private void SortChildren(OrgChartNode node)
        {
            node.Children = node.Children.OrderBy(c => c.ManagerId).ToList();
            foreach (var child in node.Children)
            {
                SortChildren(child); 
            }
        }
    }
}
