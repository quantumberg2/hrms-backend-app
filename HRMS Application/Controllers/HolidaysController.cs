using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;

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
        public List<Holiday> GetAllHolidayDetails()
        {
            _logger.LogInformation("get all Holiday details started");
            var result = _holiday.GetHoliday();
            return result;
        }
        [HttpGet("GetById")]
        public Holiday GetHoliday(int id)
        {
            _logger.LogInformation("getbyid company details started");
            var result = _holiday.GetHolidayById(id);
            return result;
        }
        [HttpPost]
        public async Task<string> InsertcompanyDetails([FromBody] Holiday holiday)
        {
            _logger.LogInformation("company details insert method started");
            var result = await _holiday.InsertHoliday(holiday);
            return result;
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
