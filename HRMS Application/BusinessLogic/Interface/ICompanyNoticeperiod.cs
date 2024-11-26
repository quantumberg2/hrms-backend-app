using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface ICompanyNoticeperiod
    {
        public List<CompanyNoticePeriod> GetCompanyNoticeperiod(int CompanyId);
        public CompanyNoticePeriod GetcoompanynoticeperiodbyId(int id);
        public Task<string> InsertCompanyNoticeperiod(CompanyNoticePeriod companyNotice, int CompanyId);
        //  public Task<ShiftRosterType> updateShiftRosterType(int id, string? Type, string? TimeRange);

        public Task<bool> deleteCompanynoticeperiod(int id);
    }
}
