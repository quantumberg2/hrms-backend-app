using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Implements;
using System.IdentityModel.Tokens.Jwt;

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

       /* [HttpGet("GetByEmpCredId")]
        public AddressInfo GetAddressInfoByEmpCredId(int empCredId)
        {
            _logger.LogInformation("get address info by empployee credential id");
             var res =  _addresInfo.GetAddressInfoByEmpCredId(empCredId);
            return res;
        }*/

        [HttpPost("insertEmployees")]
        [Authorize(new[] { "Admin" })]
        public IActionResult InsertAddressInfo([FromBody] AddressInfo addresinfo)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                // Decode the JWT token to extract claims
                var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
                var empCredentialIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "UserId");

                if (empCredentialIdClaim == null)
                {
                    return Unauthorized("Employee credential ID not found in token.");
                }

                // Parse the empCredentialId from the claim
                int empCredentialID = int.Parse(empCredentialIdClaim.Value);
                _logger.LogInformation("Insert department method started");

                var status = _addresInfo.InsertAddressInfot(addresinfo, empCredentialID);
                return Ok(status);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
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
