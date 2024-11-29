using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using HRMS_Application.Authorization;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyNoticeperiodController : ControllerBase
    {
        private readonly ICompanyNoticeperiod _companynotice;
        private readonly ILogger<CompanyNoticeperiodController> _logger;


        public CompanyNoticeperiodController(ICompanyNoticeperiod companynotice, ILogger<CompanyNoticeperiodController> logger)
        {
            _companynotice = companynotice;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(new[] { "Admin", "User", "HR" })]
        public ActionResult<CompanyNoticePeriod> Getcompanynoticeperiod()
        {
            try
            {
                _logger.LogInformation("Get companynoticeperiod method started");

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
                if (!int.TryParse(companyIdClaim.Value, out int companyId))
                {
                    return BadRequest("Invalid Company ID in token.");
                }
                var dept = _companynotice.GetCompanyNoticeperiod(companyId);
                return Ok(dept);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpPost]
        [Authorize(new[] { "Admin" })]
        public async Task<IActionResult> InsertPositions([FromBody] CompanyNoticePeriod companyNotice)
        {
            try
            {
                _logger.LogInformation("Insert CompanyNoticePeriod method started");

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
                if (!int.TryParse(companyIdClaim.Value, out int companyId))
                {
                    return BadRequest("Invalid Company ID in token.");
                }

                // Call the InsertShiftRosterType method and pass the company ID
                var status = await _companynotice.InsertCompanyNoticeperiod(companyNotice, companyId);

                // Return success status if the operation succeeded
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
            var status = await _companynotice.deleteCompanynoticeperiod(id);
            return status;
        }
    }
}
