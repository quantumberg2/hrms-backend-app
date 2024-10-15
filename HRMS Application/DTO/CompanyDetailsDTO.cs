using HRMS_Application.Models;

namespace HRMS_Application.DTO
{
    public class CompanyDetailsDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string States { get; set; }
        public string Industry { get; set; }
        public string TimeZone { get; set; }
        public string Currency { get; set; }
        public string PfNo { get; set; }
        public string TanNo { get; set; }
        public string EsiNo { get; set; }
        public string PanNo { get; set; }
        public string GstNo { get; set; }
        public string RegistrationNo { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string LinkedIn { get; set; }
        public IFormFile? CompanyLogo { get; set; }
        public int? RequestedCompanyId { get; set; }
        public short? IsActive { get; set; }
    }
}
