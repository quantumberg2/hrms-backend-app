using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface ILeaveTypes
    {
        public List<LeaveType> GetAllLeaveType();
        public LeaveType GetLeaveTypeById(int id);
        public LeaveType GetLeaveTypeByType(string Type);
        public string InsertLeaveType(LeaveType leaveType);
        public LeaveType UpdateLeaveType(int id, string? name, int? requestedcompanyId);
        public bool deleteLeaveType(int id);
    }
}
