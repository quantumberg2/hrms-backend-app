using HRMS_Application.BusinessLogic.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Authorization;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminDashboardController : ControllerBase
    {
        private readonly IAdminDashboard _adminDashboard;

        public AdminDashboardController(IAdminDashboard adminDashboard)
        {
            _adminDashboard = adminDashboard;
        }

        [HttpGet]
        [Authorize(new[] { "Admin" })]
        public async Task<IActionResult> GetDashboard()
        {
            try
            {
                var dashboardData = await _adminDashboard.GetAdminDashboardAsync();
                return Ok(dashboardData);
            }
            catch (Exception)
            {
               return StatusCode(500, "An error occurred while fetching the dashboard data.");
            }
        }
    }
}
