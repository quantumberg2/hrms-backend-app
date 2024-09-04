using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyDetailsController : ControllerBase
    {
        private readonly ICompanyDetails _companyDetails;
        private ILogger<CompanyDetailsController> _logger;
        public CompanyDetailsController(ICompanyDetails companyDetails, ILogger<CompanyDetailsController> logger)
        {
            _companyDetails = companyDetails;
            _logger = logger;
        }

        [HttpGet]
        public List<CompanyDetail> GetAllCompanyDetails()
        {
            _logger.LogInformation("get all company details started");
            var result = _companyDetails.GetAllCompanyDetails();
            return result;
        }
        [HttpGet("GetById")]
        public List<CompanyDetail> GetCompanyDetail(int id)
        {
            _logger.LogInformation("getbyid company details started");
            var result = _companyDetails.GetCompanyDetailstById(id);
            return result;
        }

        [HttpGet("GetDetailsByName")]
        public List<CompanyDetail> GetCompanyDetailstByName(string companyName)
        {
            _logger.LogInformation("Get Company details by name method started");
            var res = _companyDetails.GetCompanyDetailstByName(companyName);
            return res;
        }

        [HttpPost]
        public int InsertcompanyDetails([FromBody] CompanyDetail companyDetail)
        {
            _logger.LogInformation("company details insert method started");
            var result = _companyDetails.InsertCompanyDetails(companyDetail);
            return result;
        }
        [HttpDelete]
        public bool DeletecompanyDetails(int id)
        {
            _logger.LogInformation("company details delete method started");
            var result = _companyDetails.deleteCompanyDetails(id);
            return result;
        }
        
    }
}
