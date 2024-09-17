using HRMS_Application.DTO;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IOrgChartService
    {
       public List<OrgChartNode> GetManagersWithEmployees();

    }
}
