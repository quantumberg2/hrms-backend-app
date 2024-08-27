using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IEmployeeAttendance
    {
        public List<Attendence> GetAllEmpAttendence();
        public Attendence  GetById(int id);
        public  Task<string> InsertEmployeeAttendence(Attendence employeeAttendence);
        public Task<Attendence> UpdateEmployeeAttendence(int id, DateTime? Timein, DateTime? Timeout, string? Remark, int empcredentialId);
        public Task<bool> DeleteEmployeeAttendance(int id);
    }
}
