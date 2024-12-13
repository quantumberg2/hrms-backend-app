using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IOrganizationWorkingDays
    {
        public List<OrganizationWorkingDay> GetOrganizationWorkingDay(int CompanyId);
        public OrganizationWorkingDay GetOrganizationWorkingDayId(int id);
        public Task<string> InsertOrganizationWorkingDay(OrganizationWorkingDay organizationWorking, int CompanyId);
        //  public Task<ShiftRosterType> updateShiftRosterType(int id, string? Type, string? TimeRange);

        public Task<bool> deleteOrganizationWorkingDay(int id);
    }
}
