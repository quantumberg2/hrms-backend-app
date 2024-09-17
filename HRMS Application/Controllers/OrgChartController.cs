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

        // GET: api/OrgChart
        [HttpGet("managers-with-employees")]
        public ActionResult<List<OrgChartNode>> GetManagersWithEmployees()
        {
            var result = _orgChartService.GetManagersWithEmployees();

            if (result == null || result.Count == 0)
            {
                return NotFound("No managers with employees found.");
            }

            return Ok(result);
        }
    }
}
