/*using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Authorization;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeavesController : ControllerBase
    {
        private readonly ILeaves _leaves;
        private readonly ILogger<LeavesController> _logger;
        
        public LeavesController(ILeaves leaves, ILogger<LeavesController> logger)
        {
            _leaves = leaves;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(new[] { "Admin" })]
        public List<Leaf> GetAllLeaves()
        {
            _logger.LogInformation("Getall leaves method started");
            var dept = _leaves.GetallLeaves();
            return dept;
        }

        [HttpPost("insertEmployees")]
        [Authorize(new[] { "Admin" })]
        public string InsertLeaves([FromBody] Leaf leave)
        {
            _logger.LogInformation("Insert leaves method started");

            var status = _leaves.InsertLeave(leave);
            return status;
        }

        [HttpPut("UpdateAll/{id}")]
        [Authorize(new[] { "Admin" })]
        // [Route("UpdateAll")]
        public Leaf UpdateLeaves(int id, string? leavetype, int? days)
        {
            _logger.LogInformation("Update leaves method started");
            var status = _leaves.updateLeave(id, leavetype,days);
            return status;
        }

        [HttpDelete("{id}")]
        [Authorize(new[] { "Admin" })]
        public bool DeleteLeaves(int id)
        {
            _logger.LogInformation("Delete method started");
            var status = _leaves.deleteLeave(id);
            return status;
        }

    }
}
*/