using HRMS_Application.DTO;
using HRMS_Application.GlobalSearch;
using HRMS_Application.Models;
namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IEmpDetails
    {
        public List<EmployeeDetail> GetAllUser();
        public EmployeeDetail GetById(int id);
        public Task<string> InsertEmployeeAsync(EmployeeDetail employeeDetail, int companyId);
        public Task<EmployeeDetail> UpdateEmployeeDetail(int id, int? depId, string? fname, string? mname, string? lname, int? positionid, string? Designation, string? Email, int? employeecredentialId, string? EmployeeNumber,int? requsetCompanyId);
        public Task<bool> DeleteEmployeeDetail(int id);
        public bool SoftDelete(int id, short isActive);
        public IEnumerable<EmployeeView> GetAllEmployees();

        public List<EmployeeDetail> GetFilters(GlobalsearchEmp globalSearch);
        public Task<bool> UpdateEmployeeInfoAsync(UpdateEmployeeInfoDTO updateEmployeeInfo);
        public Task<bool> UpdateEmployeepersonalInfoAsync(EmpPersonalInfoDTO empPersonalInfo);
        public Task<bool> UpdateEmployeeAddresslInfoAsync(AddressInfoDTO addressInfo);
        public Task<bool> UpdateEmployeeAccountInfoAsync(AccountDetail accountDetail);




    }

}
