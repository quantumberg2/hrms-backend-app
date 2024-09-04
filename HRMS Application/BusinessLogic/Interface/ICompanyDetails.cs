using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface ICompanyDetails
    {
        public List<CompanyDetail> GetAllCompanyDetails();
        public List<CompanyDetail> GetCompanyDetailstById(int id);
        public List<CompanyDetail> GetCompanyDetailstByName(string companyName);
        public int InsertCompanyDetails(CompanyDetail companyDetail);
        //public CompanyDetail UpdateDepartment(int id, string? name, int? requestedcompanyId);
        public bool deleteCompanyDetails(int id);
    }
}
