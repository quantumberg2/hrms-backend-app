using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Authorization;
namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftRosterController : ControllerBase
    {
        private readonly IShiftRoster _shiftRoster;
        private readonly ILogger<ShiftRosterController> _logger;


        public ShiftRosterController(IShiftRoster shiftRoster, ILogger<ShiftRosterController> logger)
        {
            _logger = logger;
            _shiftRoster = shiftRoster;
        }
        [HttpGet]
        [Authorize(new[] { "Admin" })]
        public List<ShiftRoster> GetAllShiftRoster()
        {
            _logger.LogInformation("Getall positions method started");
            var dept = _shiftRoster.GetAllShiftRoster();
            return dept;
        }

        [HttpPost]
        [Authorize(new[] { "Admin" })]
        public async Task<string> InsertShiftRoster([FromBody] ShiftRoster shiftRoster)
        {
            _logger.LogInformation("Insert Positions method started");

            var status = await _shiftRoster.InsertShiftRoster(shiftRoster);
            return status;
        }

      /*  [HttpPut("UpdateAll/{id}")]
        [Authorize(new[] { "Admin" })]
        // [Route("UpdateAll")]
        public async Task<Position> UpdatePosition(int id, string? name, int? requestedcompanyId)
        {
            _logger.LogInformation("Update Positions method started");
            var status = await _position.updateposition(id, name, requestedcompanyId);
            return status;
        }*/

        [HttpDelete("{id}")]
        [Authorize(new[] { "Admin" })]
        public async Task<bool> DeleteShiftRoster(int id)
        {
            _logger.LogInformation("Delete method started");
            var status = await _shiftRoster.deleteShiftRoster(id);
            return status;
        }
    }
}
