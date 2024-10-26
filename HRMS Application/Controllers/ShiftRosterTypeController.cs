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
    public class ShiftRosterTypeController : ControllerBase
    {
        private readonly IShiftRostertype _shiftRostertype;
        private readonly ILogger<ShiftRosterTypeController> _logger;


        public ShiftRosterTypeController(IShiftRostertype shiftRostetype, ILogger<ShiftRosterTypeController> logger)
        {
            _shiftRostertype = shiftRostetype;
            _logger = logger;
        }
        [HttpGet]
        [Authorize(new[] { "Admin","User","HR" })]
        public ActionResult<ShiftRosterType> GetAllShiftRosterType()
        {
            try
            {
                _logger.LogInformation("Getall positions method started");

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
                var dept = _shiftRostertype.GetAllShiftRosterType(companyId);
                return Ok(dept);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpPost]
        [Authorize(new[] { "Admin" })]
        public async Task<IActionResult> InsertPositions([FromBody] ShiftRosterType shiftRosterType)
        {
            try
            {
                _logger.LogInformation("Insert Positions method started");

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
                var status = await _shiftRostertype.InsertShiftRosterType(shiftRosterType, companyId);

                // Return success status if the operation succeeded
                return Ok(status);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while inserting positions.");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("UpdateAll/{id}")]
        [Authorize(new[] { "Admin" })]
        // [Route("UpdateAll")]
        public async Task<ShiftRosterType> UpdatePosition(int id, string? Type, string? TimeRange)
        {
            _logger.LogInformation("Update Positions method started");
            var status = await _shiftRostertype.updateShiftRosterType(id, Type, TimeRange);
            return status;
        }

        [HttpDelete("{id}")]
        [Authorize(new[] { "Admin" })]
        public async Task<bool> DeletePosition(int id)
        {
            _logger.LogInformation("Delete method started");
            var status = await _shiftRostertype.deleteShiftRosterType(id);
            return status;
        }
    }
}
