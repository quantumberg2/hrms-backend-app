using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IShiftRostertype
    {
        public List<ShiftRosterType> GetAllShiftRosterType(int CompanyId);
        public ShiftRosterType GetShiftRosterTypeId(int id);
        public Task<string> InsertShiftRosterType(ShiftRosterType shiftRosterType, int CompanyId);
        public Task<ShiftRosterType> updateShiftRosterType(int id, string? Type, string? TimeRange);

        public Task<bool> deleteShiftRosterType(int id);
    }
}
