using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Authorization;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountDetailsController : ControllerBase
    {
        private readonly IAccountDetails _accountDetails;
        private readonly ILogger<AccountDetailsController> _logger;


        public AccountDetailsController(IAccountDetails accountDetails, ILogger<AccountDetailsController> logger)
        {
            _accountDetails = accountDetails;
            _logger = logger;
        }
        [HttpGet]
        //[Authorize(new[] { "Admin", "Developer" })]
        public List<AccountDetail> GetAllaccountDetails()
        {
            _logger.LogInformation("Get all department method started");
            var dept = _accountDetails.GetAllAccountdetails();
            return dept;
        }

        [HttpGet("GetById")]
        public AccountDetail GetAccountDetailsById(int id)
        {
            _logger.LogInformation("Get account details by id method started");
            var res = _accountDetails.GetAccountDetailsById(id);
            return res;
        }

        [HttpGet("GetByAccNumber")]
        public AccountDetail GetAccountDetailsByAccNumber(string accountNumber)
        {
            _logger.LogInformation("Get account details by account number method started");
            var res = _accountDetails.GetAccountDetailsByAccNumber(accountNumber);
            return res;
        }

        [HttpPost("insertEmployees")]
        [Authorize(new[] { "Admin" })]
        public string InsertDepartments([FromBody] AccountDetail accountDetail)
        {
            _logger.LogInformation("Insert department method started");

            var status = _accountDetails.InsertAccountDetails(accountDetail);
            return status;
        }


       /* [HttpPut("UpdateAll/{id}")]
        [Authorize(new[] { "Admin" })]
        // [Route("UpdateAll")]
        public Department UpdateDepartment(int id, string? name, int? requestedcompanyId)
        {
            _logger.LogInformation("Update method started");
            var status = _department.UpdateDepartment(id, name, requestedcompanyId);
            return status;
        }
*/
        [HttpDelete("{id}")]
        [Authorize(new[] { "Admin" })]
        public bool DeleteAccountDetails(int id)
        {
            _logger.LogInformation("Delete method started");
            var status = _accountDetails.deleteAccountDetails(id);
            return status;
        }
    }
}
