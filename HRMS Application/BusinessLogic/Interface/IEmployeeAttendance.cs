using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IEmployeeAttendance
    {
        public List<EmployeeAttendance> GetAllEmpAttendence();
        public EmployeeAttendance GetById(int id);
        public  Task<string> InsertEmployeeAttendence(EmployeeAttendance employeeAttendence);
        public Task<EmployeeAttendance> UpdateEmployeeAttendence(int id, DateTime? Timein, DateTime? Timeout, string? Remark, int empcredentialId);
        public Task<bool> DeleteEmployeeAttendance(int id);
    }
}
