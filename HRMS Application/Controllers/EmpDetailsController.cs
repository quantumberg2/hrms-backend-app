using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Authorization;

using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpDetailsController : ControllerBase
    {
        private readonly IEmpDetails _Empdetails;
        private readonly ILogger<EmpDetailsController> _logger;


        public EmpDetailsController(IEmpDetails EmpDetails, ILogger<EmpDetailsController> logger)
        {
            _Empdetails = EmpDetails;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(new[] { "Admin","Developer" })]
        public List<EmployeeDetail> GetAllEmpDetails()
        {
            _logger.LogInformation("Get all department method started");
            var dept = _Empdetails.GetAllUser();
            return dept;
        }
        [HttpGet("GetById")]
        [AllowAnonymous]
        public EmployeeDetail GetById(int id)
        {
           
            var status = _Empdetails.GetById(id);
            return status;
        }

        [HttpPost("insertEmployees")]
        [Authorize(new[] { "Admin" })]
        public async Task<string> InsertEmpDetails([FromBody] EmployeeDetail employeeDetail)
        {
            _logger.LogInformation("Insert Empoyeedetails method started");

            var status = await _Empdetails.InsertEmployeeDetail(employeeDetail);         
            return status;
        }

        [HttpPut("UpdateAll/{id}")]
        [Authorize(new[] { "Admin" })]
        // [Route("UpdateAll")]
        public async Task<EmployeeDetail> UpdateEmpDetails(int id, int? depId, string? mobilenumber, string? fname, string? mname, string? lname, int? positionid, string? nickname, string? gender, int? employeecredentialId)
        {
            _logger.LogInformation("Update Empoyeedetails method started");
            var status = await _Empdetails.UpdateEmployeeDetail(id, depId, mobilenumber, fname, mname, lname,positionid, nickname, gender, employeecredentialId);
            return status;
        }

        [HttpDelete("{id}")]
        [Authorize(new[] { "Admin" })]
        public async Task<bool> DeleteEmpDetails(int id)
        {
            _logger.LogInformation("Delete method started");
            var status = await _Empdetails.DeleteEmployeeDetail(id);
            return status;
        }
    }
}
