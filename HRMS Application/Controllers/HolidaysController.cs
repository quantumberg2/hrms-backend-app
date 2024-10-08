using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using System.IdentityModel.Tokens.Jwt;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidaysController : ControllerBase
    {
        private readonly IHoliday _holiday;
        private readonly ILogger<HolidaysController> _logger;
        public HolidaysController(IHoliday holiday, ILogger<HolidaysController> logger)
        {
            _holiday = holiday;
            _logger = logger;
        }
        [HttpGet]
        public ActionResult<List<Holiday>> GetAllHolidayDetails()
        {
            try
            {
                _logger.LogInformation("Get all Holiday details started.");

                // Retrieve the Authorization token from the headers
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

                // Call the service to get the holiday list based on the company ID
                var result = _holiday.GetHoliday(companyId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the holiday details.");
                return StatusCode(500, "An error occurred while fetching holiday data.");
            }
        }

        [HttpGet("GetById")]
        public Holiday GetHoliday(int id)
        {
            _logger.LogInformation("getbyid company details started");
            var result = _holiday.GetHolidayById(id);
            return result;
        }
        [HttpPost]
        public async Task<IActionResult> InsertcompanyDetails([FromBody] Holiday holiday)
        {
            try
            {
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

                holiday.CompanyId = companyId;

                _logger.LogInformation("LeaveType details insert method started");
                _logger.LogInformation("company details insert method started");
                var result = await _holiday.InsertHoliday(holiday);
                return Ok("Holidays successfully inserted.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while inserting leave type details.");
                return StatusCode(500, "An error occurred while inserting leave type details.");
            }
        }
        [HttpDelete]
        public async Task<bool> DeletecompanyDetails(int id)
        {
            _logger.LogInformation("company details delete method started");
            var result = await _holiday.deleteHoliday(id);
            return result;
        }

        [HttpPut("SoftDelete")]
/*        [Authorize(new[] { "Admin" })]
*/
        public bool SoftDelete(int id, short isActive)
        {
            _logger.LogInformation("Soft update holiday method started");
            var res = _holiday.SoftDelete(id, isActive);
            return res;

        }

        [HttpPut("id")]
        [Authorize(new[] { "Admin" })]
        public IActionResult UpdateHolidayType(int id, string? name, DateOnly? date, string? Occation, int? requestedCompanyId)

        {
            _logger.LogInformation(" update holiday method started");
            var res = _holiday.UpdateHolidayType(id, name,date,Occation,requestedCompanyId);
            return Ok(res);

        }

    }
}
