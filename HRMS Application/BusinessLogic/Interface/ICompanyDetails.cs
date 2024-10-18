using HRMS_Application.DTO;
using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface ICompanyDetails
    {
        public List<CompanyDetail> GetAllCompanyDetails();
        public List<CompanyDetail> GetCompanyDetailstById(int id);
        public List<ComanyLogoDTO> GetCompanyDetailstByCompanyId(int CompanyID);
        public string updateCompanyLogo(IFormFile companyLogo, int companyId);
        public string InsertCompanyDetails(CompanyDetailsDTO companyDetail, int companyId);
        //public CompanyDetail UpdateDepartment(int id, string? name, int? requestedcompanyId);
        public bool deleteCompanyDetails(int id);
        public bool SoftDelete(int id, short isActive);
    }
}
