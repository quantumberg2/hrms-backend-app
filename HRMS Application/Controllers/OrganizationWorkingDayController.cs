using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using HRMS_Application.Authorization;
using System.ComponentModel.Design;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationWorkingDayController : ControllerBase
    {
        private readonly IOrganizationWorkingDays _organizationworking;
        private readonly ILogger<OrganizationWorkingDayController> _logger;


        public OrganizationWorkingDayController(IOrganizationWorkingDays organizationworking, ILogger<OrganizationWorkingDayController> logger)
        {
            _organizationworking = organizationworking;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(new[] { "Admin", "User", "HR" })]
        public ActionResult<OrganizationWorkingDay> GetOrganizationWorkingDay()
        {
            try
            {
                _logger.LogInformation("Get OrganizationWorkingDay method started");

                // Extract the JWT token from the Authorization header
                var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer", "").Trim();
                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Authorization token is missing or invalid.");
                }

                // Decode the JWT token to get the company ID
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                var companyIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "CompanyId");
                if (companyIdClaim == null)
                {
                    return Unauthorized("Company ID not found in token.");
                }

                // Parse the company ID from the claim
                if (!int.TryParse(companyIdClaim.Value, out int CompanyId))
                {
                    return BadRequest("Invalid Company ID in token.");
                }
                var dept = _organizationworking.GetOrganizationWorkingDay(CompanyId);
                return Ok(dept);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpPost]
        [Authorize(new[] { "Admin" })]
        public async Task<IActionResult> InsertOrganizationWorkingDay([FromBody] OrganizationWorkingDay organizationWorking)
        {
            try
            {
                _logger.LogInformation("Insert OrganizationWorkingDay method started");

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

                if (!int.TryParse(companyIdClaim.Value, out int CompanyId))
                {
                    return BadRequest("Invalid Company ID in token.");
                }

                var status = await _organizationworking.InsertOrganizationWorkingDay(organizationWorking, CompanyId);

                return Ok(status);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while inserting positions.");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /*  [HttpPut("UpdateAll/{id}")]
          [Authorize(new[] { "Admin" })]
          // [Route("UpdateAll")]
          public async Task<com> UpdatePosition(int id, string? Type, string? TimeRange)
          {
              _logger.LogInformation("Update Positions method started");
              var status = await _shiftRostertype.updateShiftRosterType(id, Type, TimeRange);
              return status;
          }*/

        [HttpDelete("{id}")]
        [Authorize(new[] { "Admin" })]
        public async Task<bool> DeletePosition(int id)
        {
            _logger.LogInformation("Delete method started");
            var status = await _organizationworking.deleteOrganizationWorkingDay(id);
            return status;
        }
    }

}

