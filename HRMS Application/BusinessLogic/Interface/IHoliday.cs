using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IHoliday
    {
        public List<Holiday> GetHoliday();
        public Holiday GetHolidayById(int id);
      public Task<string> InsertHoliday(Holiday holiday);
      //public LeaveType UpdateLeaveType(int id, string? name, int? requestedcompanyId);
        public Task<bool> deleteHoliday(int id);
        public bool SoftDelete(int id, short isActive);
    }
}
