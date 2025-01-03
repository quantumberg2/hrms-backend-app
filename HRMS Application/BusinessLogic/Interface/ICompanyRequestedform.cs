﻿using HRMS_Application.DTO;
using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface ICompanyRequestedform
    {
        public List<RequestedCompanyForm> GetAllRequestedCompanyForm();
        public RequestedCompanyForm GetById(int id);
        public Task<string> InsertRequestedCompanyForm(RequestedCompanyForm requestedcompanyform);
        // public Task<RequestedCompanyForm> UpdateEmployeeAttendence(int id, DateTime? Timein, DateTime? Timeout, string? Remark, int empcredentialId);
        public Task<bool> DeleteRequestedCompanyForm(int id);
        // public Task<string> GenerateAndSendOtp(string email);
        // public Task<string> UpdatePassword(string email, string otp, string newPassword);

        public bool SoftDelete(int id, short isActive);




    }
}
