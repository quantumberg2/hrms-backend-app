using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IEmpLeaveAllocation
    {
        public List<EmployeeLeaveAllocation> GetAllEmpLeave();
        public EmployeeLeaveAllocation GetByEmpLeavebyId(int id);
        public Task<string> InsertEmployeeLeave(EmployeeLeaveAllocation employeeLeave);
        public Task<bool> DeleteEmployeeLeave(int id);
    }
}