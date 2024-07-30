using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Authorization;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeLeaveController : ControllerBase
    {
        private readonly IEmployeeLeave _employeeleave;
        private readonly ILogger<EmployeeLeaveController> _logger;

        public EmployeeLeaveController(IEmployeeLeave employeeLeave, ILogger<EmployeeLeaveController> logger)
        {
            _employeeleave = employeeLeave;
            _logger = logger;
        }
        [HttpGet]
        [Authorize(new[] { "Admin", "Developer" })]
        public List<EmployeeLeave> GetAllEmpleaves()
        {
            _logger.LogInformation("Get all employee leave method started");
            var dept = _employeeleave.GetAllEmpLeave();
            return dept;
        }
        [HttpGet("GetById")]
        [AllowAnonymous]
        public EmployeeLeave GetById(int id)
        {
            _logger.LogInformation("Get  employeeleave by id method started");

            var status = _employeeleave.GetByEmpLeavebyId(id);
            return status;
        }

        [HttpPost("insertEmployees")]
        [Authorize(new[] { "Admin" })]
        public string InsertEmpLeaves([FromBody] EmployeeLeave employeeLeave)
        {
            _logger.LogInformation("Insert employee leave method started");

            var status = _employeeleave.InsertEmployeeLeave(employeeLeave);
            return status;
        }

     /*   [HttpPut("UpdateAll/{id}")]
        [Authorize(new[] { "Admin" })]
        // [Route("UpdateAll")]
        public EmployeeDetail UpdateEmpDetails(int id, int? depId, string? mobilenumber, string? fname, string? mname, string? lname, int? positionid, string? nickname, string? gender, string? loginusername, string? password, string? role)
        {
            _logger.LogInformation("Update Empoyeedetails method started");
            var status = _Empdetails.UpdateEmployeeDetail(id, depId, mobilenumber, fname, mname, lname, positionid, nickname, gender, loginusername, password, role);
            return status;
        }*/

        [HttpDelete("{id}")]
        [Authorize(new[] { "Admin" })]
        public bool DeleteEmpDetails(int id)
        {
            _logger.LogInformation("Delete method started");
            var status = _employeeleave.DeleteEmployeeLeave(id);
            return status;
        }
    }
}
