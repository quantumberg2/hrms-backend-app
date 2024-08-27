using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IEmpCredential
    {
        public List<EmployeeCredential> GetAllEmpCredential();
        public EmployeeCredential GetById(int id);
        public Task<string> InsertEmployeeCredential(EmployeeCredential employeeCredential);
        public Task<EmployeeCredential> UpdateEmployeeCredentials(int id, string? username, string? password, short? status, int? requestedCompanyId);
        public Task<string> UpdateEmployeePassword(string email, string oldPassword, string newPassword);
        public Task<bool> DeleteEmployeeCredential(int id);
        public Task<string> GenerateAndSendOtp(string email);
        public Task<string> UpdatePassword(string email, string otp, string newPassword, string confirmPassword);
    }
}

