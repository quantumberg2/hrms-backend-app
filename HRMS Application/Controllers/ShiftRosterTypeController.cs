using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Authorization;

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
        public List<ShiftRosterType> GetAllShiftRosterType()
        {
            _logger.LogInformation("Getall positions method started");
            var dept = _shiftRostertype.GetAllShiftRosterType();
            return dept;
        }

        [HttpPost]
        [Authorize(new[] { "Admin" })]
        public async Task<string> InsertPositions([FromBody] ShiftRosterType shiftRosterType)
        {
            _logger.LogInformation("Insert Positions method started");

            var status = await _shiftRostertype.InsertShiftRosterType(shiftRosterType);
            return status;
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
