﻿using HRMS_Application.DTO;
using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface ILeaveTracking
    {
     public Task<List<LeaveApprovalDTO>> GetLeavesByStatusAsync(string status);
     public Task<IEnumerable<LeaveTracking>> GetAllAsync();
     public Task<LeaveTracking> GetByIdAsync(int id);
     public Task<LeaveTracking> CreateAsync(LeaveTracking leaveTracking, int empCredentialId);
     public Task<LeaveTracking> ApllyLeaveBehalf(LeaveTracking leaveTracking, int empCredentialId);
     public Task<LeaveTracking> UpdateAsync(LeaveTracking leaveTracking);
     public Task<LeaveTracking> UpdateLeaveAsync(int id, string newStatus);
     public Task<bool> DeleteAsync(int id);
     public Task<LeaveSummaryDTO> GetEmployeeLeaveSummaryAsync(int employeeCredentialId, int year);
     public bool SoftDelete(int id, short isActive);

    }
}