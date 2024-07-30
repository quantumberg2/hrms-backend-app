using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IEmployeeLeave
    {
        public List<EmployeeLeave> GetAllEmpLeave();
        public EmployeeLeave GetByEmpLeavebyId(int id);
        public Task<string> InsertEmployeeLeave(EmployeeLeave employeeLeave);
        //public EmployeeLeave UpdateEmployeeLeave(int id, int? depId, string? mobilenumber, string? fname, string? mname, string? lname, int? positionid, string? nickname, string? gender, string? loginusername, string? password, string? role);
        public Task<bool> DeleteEmployeeLeave(int id);
    }
}
