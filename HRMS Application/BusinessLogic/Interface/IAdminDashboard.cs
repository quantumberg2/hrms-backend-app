using HRMS_Application.DTO;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IAdminDashboard
    {
        public Task<AdminDashboardDTO> GetAdminDashboardAsync(int comapnyId);

    }
}
