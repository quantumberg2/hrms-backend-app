using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IHoliday
    {
        public List<Holiday> GetHoliday(int companyId);
        public Holiday GetHolidayById(int id);
      public Task<string> InsertHoliday(Holiday holiday);
        public Holiday UpdateHolidayType(int id, string? name, DateOnly? date, string? Occation, int? requestedCompanyId);
        public Task<bool> deleteHoliday(int id);
        public bool SoftDelete(int id, short isActive);
    }
}
