using HRMS_Application.DTO;
using HRMS_Application.GlobalSearch;
using HRMS_Application.Models;
namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IEmpDetails
    {
        public List<EmployeeDetail> GetAllUser();
        public EmployeeDetail GetById(int id);
        public Task<string> InsertEmployeeAsync(IFormFile? imageFile, int? depId, string? fname, string? mname, string? lname, int? positionid, string? email, string? empNumber,int? managerId, string? nickName,string? extention,string? mobNumber, string? experience, int companyId);
        public Task<EmployeeDetail> UpdateEmployeeDetail(IFormFile? imageFile, int id, int? depId, string? fname, string? mname, string? lname, int? positionid, string? Designation, string? Email, int? employeecredentialId, string? EmployeeNumber,int? requsetCompanyId);
        public Task<bool> DeleteEmployeeDetail(int id);
        public bool SoftDelete(int id, short isActive);
        public IEnumerable<EmployeeView> GetAllEmployees();

        public Task<UpdateEmployeeInfoDTO> GetEmployeeInfoAsync(int employeeCredentialId);
        public Task<EmpPersonalInfoDTO> GetEmployeePersonalInfoAsync(int employeeCredentialId);
        public Task<AddressInfoDTO> GetEmployeeAddressInfoAsync(int employeeCredentialId);
        public Task<AccountDetail> GetEmployeeAccountInfoAsync(int employeeCredentialId);
        public List<EmployeeDetail> GetFilters(GlobalsearchEmp globalSearch);
        public Task<bool> UpdateEmployeeInfoAsync(int? empCredId, string? empName, string? nickName, string? emailAddress, string? empLoginName, string? extension, string? mobileNumber, string? gender, IFormFile? imageUrl);
        public Task<bool> UpdateEmployeepersonalInfoAsync(EmpPersonalInfoDTO empPersonalInfo);
        public Task<bool> UpdateEmployeeAddresslInfoAsync(AddressInfoDTO addressInfo);
        public Task<bool> UpdateEmployeeAccountInfoAsync(AccountDetail accountDetail);
        public EmployeeShiftAndLeaveStatsDto GetEmployeeShiftAndLeaveStats(int empCredentialId);





    }

}
