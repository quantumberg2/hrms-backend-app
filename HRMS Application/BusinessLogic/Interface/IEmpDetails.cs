using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IEmpDetails
    {
        public List<EmployeeDetail> GetAllUser();
        public EmployeeDetail GetById(int id);
        public Task<string> InsertEmployeeDetail(EmployeeDetail employeeDetail);
        public Task<EmployeeDetail> UpdateEmployeeDetail(int id, int? depId, string? mobilenumber, string? fname, string? mname, string? lname, int? positionid, string? nickname, string? gender, int? employeecredentialId);
        public Task<bool> DeleteEmployeeDetail(int id);
    }
}
