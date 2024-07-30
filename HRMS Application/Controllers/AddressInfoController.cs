using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Authorization;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressInfoController : ControllerBase
    {
        private readonly IAddressInfo _addresInfo;
        private readonly ILogger<AddressInfoController> _logger;


        public AddressInfoController(IAddressInfo addressInfo, ILogger<AddressInfoController> logger)
        {
            _addresInfo = addressInfo;
            _logger = logger;
        }
        [HttpGet]
        //[Authorize(new[] { "Admin", "Developer" })]
        public List<AddressInfo> GetAllAddressInfo()
        {
            _logger.LogInformation("Get all department method started");
            var res = _addresInfo.GetAllAddressInfo();
            return res;
        }

        [HttpPost("insertEmployees")]
        [Authorize(new[] { "Admin" })]
        public string InsertAddressInfo([FromBody] AddressInfo addresinfo)
        {
            _logger.LogInformation("Insert department method started");

            var status = _addresInfo.InsertAddressInfot(addresinfo);
            return status;
        }

        /*[HttpPut("UpdateAll/{id}")]
        [Authorize(new[] { "Admin" })]
        // [Route("UpdateAll")]
        public AddressInfo UpdateAddressInfo(int id, string? name, int? requestedcompanyId)
        {
            _logger.LogInformation("Update method started");
            var status = _department.UpdateDepartment(id, name, requestedcompanyId);
            return status;
        }*/

        [HttpDelete("{id}")]
        [Authorize(new[] { "Admin" })]
        public bool DeleteAddressInfo(int id)
        {
            _logger.LogInformation("Delete method started");
            var status = _addresInfo.deleteAddressInfo(id);
            return status;
        }
    }
}
