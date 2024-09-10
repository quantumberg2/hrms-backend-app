using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IShiftRoster
    {
        public List<ShiftRoster> GetAllShiftRoster();
        public ShiftRoster GetShiftRosterId(int id);
        public Task<string> InsertShiftRoster(ShiftRoster shiftRoster);
        public Task<bool> deleteShiftRoster(int id);
    }
}
