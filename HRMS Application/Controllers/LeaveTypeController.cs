using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Authorization;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly ILeaveTypes _leavetype;
        private readonly ILogger<LeaveTypeController> _logger;
        public LeaveTypeController(ILeaveTypes leavetype, ILogger<LeaveTypeController> logger)
        {
            _leavetype = leavetype;
            _logger = logger;
        }
        [HttpGet]
        public List<LeaveType> GetAllLeavetype()
        {
            _logger.LogInformation("get all leavetypes details started");
            var result = _leavetype.GetAllLeaveType();
            return result;
        }
        [HttpGet("GetById")]
        public LeaveType GetleavetypeById(int id)
        {
            _logger.LogInformation("getbyid leavetypes details started");
            var result = _leavetype.GetLeaveTypeById(id);
            return result;
        }
       
        [HttpPost]
        [Authorize(new[] { "Admin" })]

        public async Task<string> InsertLeavetypes([FromBody] LeaveType leaveType)
        {
            _logger.LogInformation("leavetypes details insert method started");
            var result = await _leavetype.InsertLeaveType(leaveType);
            return result;
        }
        [HttpDelete]
        public bool DeleteLeavetype(int id)
        {
            _logger.LogInformation("leavetypes details delete method started");
            var result = _leavetype.deleteLeaveType(id);
            return result;
        }

        [HttpPut("SoftDelete")]
        [Authorize(new[] { "Admin" })]

        public bool SoftDelete(int id, short isActive)
        {
            _logger.LogInformation("Soft update leave type method started");
            var res = _leavetype.SoftDelete(id, isActive);
            return res;

        }
    }
}
