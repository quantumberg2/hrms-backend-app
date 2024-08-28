using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface ILeaveTracking
    {
     public Task<IEnumerable<LeaveTracking>> GetAllAsync();
     public Task<LeaveTracking> GetByIdAsync(int id);
     public Task<LeaveTracking> CreateAsync(LeaveTracking leaveTracking, int empCredentialId);
     public Task<LeaveTracking> UpdateAsync(LeaveTracking leaveTracking);
     public Task<bool> DeleteAsync(int id);
    }
}
