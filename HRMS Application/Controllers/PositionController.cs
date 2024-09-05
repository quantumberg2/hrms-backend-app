using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Authorization;


namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPosition _position;
        private readonly ILogger<PositionController> _logger;


        public PositionController(IPosition position, ILogger<PositionController> logger)
        {
            _position = position;
            _logger = logger;
        }
        [HttpGet]
        [Authorize(new[] { "Admin" })]
        public List<Position> GetAllPositions()
        {
            _logger.LogInformation("Getall positions method started");
            var dept = _position.GetPositions();
            return dept;
        }

        [HttpPost("insertEmployees")]
        [Authorize(new[] { "Admin" })]
        public async Task<string> InsertPositions([FromBody] Position position)
        {
            _logger.LogInformation("Insert Positions method started");

            var status = await _position.InsertPositions(position);
            return status;
        }

        [HttpPut("UpdateAll/{id}")]
        [Authorize(new[] { "Admin" })]
        // [Route("UpdateAll")]
        public async Task<Position> UpdatePosition(int id, string? name, int? requestedcompanyId)
        {
            _logger.LogInformation("Update Positions method started");
            var status = await _position.updateposition(id, name, requestedcompanyId);
            return status;
        }

        [HttpDelete("{id}")]
        [Authorize(new[] { "Admin" })]
        public async Task<bool> DeletePosition(int id)
        {
            _logger.LogInformation("Delete method started");
            var status = await  _position.deletePosition(id);
            return status;
        }

        [HttpPut("SoftDelete")]
        [Authorize(new[] { "Admin" })]

        public bool SoftDelete(int id, short isActive)
        {
            _logger.LogInformation("Soft update position method started");
            var res = _position.SoftDelete(id, isActive);
            return res;

        }
    }
}
