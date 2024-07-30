using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface ICompanyDetails
    {
        public List<CompanyDetail> GetAllCompanyDetails();
        public CompanyDetail GetCompanyDetailstById(int id);
        public int InsertCompanyDetails(CompanyDetail companyDetail);
        //public CompanyDetail UpdateDepartment(int id, string? name, int? requestedcompanyId);
        public bool deleteCompanyDetails(int id);
    }
}
