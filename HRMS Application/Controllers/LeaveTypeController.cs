using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            _logger.LogInformation("get all Holiday details started");
            var result = _leavetype.GetAllLeaveType();
            return result;
        }
        [HttpGet("GetById")]
        public LeaveType GetleavetypeById(int id)
        {
            _logger.LogInformation("getbyid company details started");
            var result = _leavetype.GetLeaveTypeById(id);
            return result;
        }
        [HttpPost]
        public string InsertLeavetypes([FromBody] LeaveType leaveType)
        {
            _logger.LogInformation("company details insert method started");
            var result = _leavetype.InsertLeaveType(leaveType);
            return result;
        }
        [HttpDelete]
        public bool DeleteLeavetype(int id)
        {
            _logger.LogInformation("company details delete method started");
            var result = _leavetype.deleteLeaveType(id);
            return result;
        }
    }
}
