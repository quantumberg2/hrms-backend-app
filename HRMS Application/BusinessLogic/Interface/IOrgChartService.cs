using HRMS_Application.DTO;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IOrgChartService
    {
        // public List<OrgChartNode> GetManagersWithEmployees();
        public Task<OrgChartNode> GetOrganizationChartAsync(int companyId);


    }
}
