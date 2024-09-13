using HRMS_Application.BusinessLogic.Interface;
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

        // GET: api/OrgChart
        [HttpGet]
        public async Task<IActionResult> GetOrgChart()
        {
            try
            {
                // Fetch the organizational chart data
                var orgChart = await _orgChartService.GetOrgChartAsync();

                if (orgChart == null || orgChart.Count == 0)
                {
                    return NotFound("Organizational chart data not found.");
                }

                // Return the org chart data
                return Ok(orgChart);
            }
            catch (Exception ex)
            {
                // Handle the error and return a 500 Internal Server Error
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
