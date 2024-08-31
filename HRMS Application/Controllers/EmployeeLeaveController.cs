using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Authorization;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpLeaveAllocationController : ControllerBase
    {
        private readonly IEmpLeaveAllocation _employeeLeaveService;
        private readonly ILogger<EmpLeaveAllocationController> _logger;

        public EmpLeaveAllocationController(IEmpLeaveAllocation employeeLeaveService, ILogger<EmpLeaveAllocationController> logger)
        {
            _employeeLeaveService = employeeLeaveService;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(new[] { "Admin", "Developer" })]
        public IActionResult GetAllEmpleaves()
        {
            _logger.LogInformation("Get all employee leave method started");
            var dept = _employeeLeaveService.GetAllEmpLeave();
            return Ok(dept);
        }

        [HttpGet("GetById/{id}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            _logger.LogInformation("Get employee leave by ID method started");
            var status = _employeeLeaveService.GetByEmpLeavebyId(id);
            if (status == null)
            {
                return NotFound("Employee leave not found");
            }
            return Ok(status);
        }

        [HttpPost("InsertEmployeeLeave")]
        [Authorize(new[] { "Admin" })]
        public async Task<IActionResult> InsertEmpLeaves([FromBody] EmployeeLeaveAllocation employeeLeave)
        {
            _logger.LogInformation("Insert employee leave method started");

            var status = await _employeeLeaveService.InsertEmployeeLeave(employeeLeave);
            if (status == "new Employeeleave inserted successfully")
            {
                return CreatedAtAction(nameof(GetById), new { id = employeeLeave.Id }, employeeLeave);
            }
            return BadRequest(status);
        }

        [HttpDelete("{id}")]
        [Authorize(new[] { "Admin" })]
        public async Task<IActionResult> DeleteEmpDetails(int id)
        {
            _logger.LogInformation("Delete method started");
            var result = await _employeeLeaveService.DeleteEmployeeLeave(id);
            if (!result)
            {
                return NotFound("Employee leave not found");
            }
            return NoContent();
        }
    }
}