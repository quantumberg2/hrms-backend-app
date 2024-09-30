using HRMS_Application.DTO;
using HRMS_Application.GlobalSearch;
using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IUpdateEmployeeDetails
    {
        public Task<UpdateEmployeeInfoDTO> GetEmployeeInfoAsync(int employeeCredentialId);
        public Task<EmpPersonalInfoDTO> GetEmployeePersonalInfoAsync(int employeeCredentialId);
        public Task<AddressInfoDTO> GetEmployeeAddressInfoAsync(int employeeCredentialId);
        public Task<AccountDetail> GetEmployeeAccountInfoAsync(int employeeCredentialId);
        public Task<bool> UpdateEmployeeInfoAsync(UpdateEmployeeInfoDTO updateEmployeeInfo);
        public Task<bool> UpdateEmployeepersonalInfoAsync(EmpPersonalInfoDTO empPersonalInfo);
        public Task<bool> UpdateEmployeeAddresslInfoAsync(AddressInfoDTO addressInfo);
        public Task<bool> UpdateEmployeeAccountInfoAsync(AccountDetail accountDetail);

    }
}
