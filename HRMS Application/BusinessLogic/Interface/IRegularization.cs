using HRMS_Application.DTO;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IRegularization
    {
        public List<LeavePendingDTO> GetPendingRegularization(int employeeCredentialId, string status);
        public Task<List<LeaveApprovalDTO>> GetRegularizationByStatusAsync(string status, int managerId);

    }
}
