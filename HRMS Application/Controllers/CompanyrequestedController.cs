using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Authorization;
namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyrequestedController : ControllerBase
    {
        private readonly ICompanyRequestedform _companyRequested;
        private readonly ILogger<CompanyrequestedController> _logger;
        public CompanyrequestedController(ICompanyRequestedform companyRequested, ILogger<CompanyrequestedController> logger)
        {
            _companyRequested = companyRequested;
            _logger = logger;
        }
        [HttpGet]
       // [Authorize(new[] { "Admin" })]
        public List<RequestedCompanyForm> GetEmpCredential()
        {
            _logger.LogInformation("Get All Employee Credential started");
            var result = _companyRequested.GetAllRequestedCompanyForm();
            return result;

        }
        [HttpGet("GetById")]
        public RequestedCompanyForm GetEmployeeCredentialsById(int id)
        {
            _logger.LogInformation("Getby ID for Employee Credential method started");
            var result = _companyRequested.GetById(id);
            return result;
        }

        [HttpDelete]
        //[Authorize(new[] { "Admin" })]
        public async Task<bool> DeleteRequestedCompanyForm(int id)
        {
            _logger.LogInformation("Delete Employee Credential method was started");
            var result = await _companyRequested.DeleteRequestedCompanyForm(id);
            return result;
        }
        [HttpPost]
        //[Authorize(new[] { "Admin" })]
        public async Task<string> InsertRequestedCompanyForm([FromBody] RequestedCompanyForm requestedCompanyForm)
        {
            _logger.LogInformation("Insert Employee Credential method started");
            var result = await _companyRequested.InsertRequestedCompanyForm(requestedCompanyForm);
            return result;

        }
    }
}
