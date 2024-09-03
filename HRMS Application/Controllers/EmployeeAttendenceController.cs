using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Authorization;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAttendenceController : ControllerBase
    {
        private readonly IEmployeeAttendance _employeeAttendence;
        private readonly ILogger<EmployeeAttendenceController> _logger;

        public EmployeeAttendenceController(IEmployeeAttendance employeeAttendence, ILogger<EmployeeAttendenceController> logger)
        {
            _employeeAttendence = employeeAttendence;
            _logger = logger;
        }
        [HttpGet]
        [Authorize(new[] { "Admin", "Developer" })]
        public List<Attendance> GetAllEmpDetails()
        {
            _logger.LogInformation("Get all department method started");
            var dept = _employeeAttendence.GetAllEmpAttendence();
            return dept;
        }
        [HttpGet("GetById")]
        [AllowAnonymous]
        public Attendance GetById(int id)
        {

            var status = _employeeAttendence.GetById(id);
            return status;
        }

        [HttpPost("insertEmployees")]
        [Authorize(new[] { "Admin" })]
        public async Task<string> InsertEmpAttendence([FromBody] Attendance employeeAttendance)
        {
            _logger.LogInformation("Insert Empoyeedetails method started");

            var status = await _employeeAttendence.InsertEmployeeAttendence(employeeAttendance);
            return status;
        }

        [HttpPut("UpdateAll/{id}")]
        [Authorize(new[] { "Admin" })]
        // [Route("UpdateAll")]
        public async Task<Attendance> UpdateEmpDetails(int id, DateTime? Timein, DateTime? Timeout, string? Remark, int empcredentialId)
        {
            _logger.LogInformation("Update Empoyeedetails method started");
            var status = await _employeeAttendence.UpdateEmployeeAttendence(id, Timein, Timeout, Remark, empcredentialId);
            return status;
        }

        [HttpDelete("{id}")]
        [Authorize(new[] { "Admin" })]
        public async Task<bool> DeleteEmpAttendence(int id)
        {
            _logger.LogInformation("Delete method started");
            var status = await _employeeAttendence.DeleteEmployeeAttendance(id);
            return status;
        }
    }
}
