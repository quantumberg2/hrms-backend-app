using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly ILeaveTypes _leavetype;
        private readonly ILogger<LeaveTypeController> _logger;
        public LeaveTypeController(ILeaveTypes leavetype, ILogger<LeaveTypeController> logger)
        {
            _leavetype = leavetype;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(new[] { "Admin","User","HR" })]
        public ActionResult <List<LeaveType>> GetAllLeavetype()
        {
            try
            {
                _logger.LogInformation("get all leavetypes details started");
                var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer", "").Trim();
                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Authorization token is missing or invalid.");
                }

                // Decode the JWT token to extract the CompanyId
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                // Extract the CompanyId from the token
                var companyIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "CompanyId");
                if (companyIdClaim == null)
                {
                    return Unauthorized("Company ID not found in token.");
                }

                // Parse the CompanyId
                if (!int.TryParse(companyIdClaim.Value, out int companyId))
                {
                    return BadRequest("Invalid Company ID in token.");
                }

                var result = _leavetype.GetAllLeaveType(companyId);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the Leave Types details.");
                return StatusCode(500, "An error occurred while fetching Leave Types data.");
            }
        }
        [HttpGet("GetById")]
        public LeaveType GetleavetypeById(int id)
        {
            _logger.LogInformation("getbyid leavetypes details started");
            var result = _leavetype.GetLeaveTypeById(id);
            return result;
        }
       
       
        [HttpPost]
        [Authorize(new[] { "Admin" })]
        public async Task<IActionResult> InsertLeavetypes([FromBody] LeaveType leaveType)
        {
            try
            {
                _logger.LogInformation("InsertLeavetypes method started");

                var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer", "").Trim();
                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Authorization token is missing or invalid.");
                }

                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);
                
                var companyIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "CompanyId");
                if (companyIdClaim == null)
                {
                    return Unauthorized("Company ID not found in token.");
                }

                if (!int.TryParse(companyIdClaim.Value, out int companyId))
                {
                    return BadRequest("Invalid Company ID in token.");
                }

                leaveType.CompanyId = companyId;
              //  leaveType.CompanyConfiguredLeave = true;

                _logger.LogInformation("LeaveType details insert method started");

                // Call the async InsertLeaveType method
                var result = await _leavetype.InsertLeaveType(leaveType);

                // Return success message
                return Ok("LeaveType successfully inserted.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while inserting leave type details.");
                return StatusCode(500, "An error occurred while inserting leave type details.");
            }
        }

        [HttpDelete]
        public bool DeleteLeavetype(int id)
        {
            _logger.LogInformation("leavetypes details delete method started");
            var result = _leavetype.deleteLeaveType(id);
            return result;
        }

        [HttpPut("SoftDelete")]
        [Authorize(new[] { "Admin" })]
           
        public bool SoftDelete(int id, short isActive)
        {
            _logger.LogInformation("Soft update leave type method started");
            var res = _leavetype.SoftDelete(id, isActive);
            return res;

        }

        [HttpPut("id")]
        [Authorize(new[] { "Admin" })]
        public IActionResult UpdateLeaveType(int id, string? name, int? days, int? year, int? requestedcompanyId)

        {
            _logger.LogInformation(" update Leave type method started");
            var res = _leavetype.UpdateLeaveType(id, name, days, year, requestedcompanyId);
            return Ok(res);

        }
    }
}
