
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Authorization;
using System.IdentityModel.Tokens.Jwt;
using HRMS_Application.DTO;

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

        [HttpGet("GetByEmpCredId(from JWT)")]
        [AllowAnonymous]
        public IActionResult GetAttendanceByCredId()
        {
            _logger.LogInformation("Get Attendance details by Employee Credential Id method started ");

            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var empCredentialIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "UserId");

            if (empCredentialIdClaim == null)
            {
                return Unauthorized("Employee credential ID not found in token.");
            }

            // Parse the empCredentialId from the claim
            int empCredentialId = int.Parse(empCredentialIdClaim.Value);

            var res = _employeeAttendence.GetAttendanceByCredId(empCredentialId);
            return Ok(res);
        }

        [HttpGet("GetByCredId")]
        [Authorize(new[] {"Admin", "Manager"})]
        public IActionResult GetAttendanceByCredId(int empCredId)
        {
            _logger.LogInformation("Get Attendance details by passing Employee credential id method started");
            var res = _employeeAttendence.GetAttendanceByCredId(empCredId);
            return Ok(res);
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
