using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgChartController : ControllerBase
    {
        private readonly IOrgChartService _orgChartService;

        public OrgChartController(IOrgChartService orgChartService)
        {
            _orgChartService = orgChartService;
        }

        [HttpGet("organization-chart")]
        public async Task<IActionResult> GetOrganizationChart()
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
                var orgChart = await _orgChartService.GetOrganizationChartAsync(companyId);
                return Ok(orgChart); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
