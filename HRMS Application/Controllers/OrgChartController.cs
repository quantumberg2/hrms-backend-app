using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
                var orgChart = await _orgChartService.GetOrganizationChartAsync();
                return Ok(orgChart); // Return the hierarchy
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
