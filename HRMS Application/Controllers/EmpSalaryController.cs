using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Authorization;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpSalaryController : ControllerBase
    {
        private readonly IEmployeeSalary _empsalary;
        private readonly ILogger<EmpSalaryController> _logger;


        public EmpSalaryController(IEmployeeSalary empsalry, ILogger<EmpSalaryController> logger)
        {
            _empsalary = empsalry;
            _logger = logger;
        }
        [HttpGet]
        //[Authorize(new[] { "Admin", "Developer" })]
        public List<EmpSalary> GetAllEmpsalary()
        {
            _logger.LogInformation("Get all department method started");
            var dept = _empsalary.GetAllEmpSalary();
            return dept;
        }

        [HttpPost("insertEmployees")]
        [Authorize(new[] { "Admin" })]
        public async Task<string> InsertEmpsalary([FromBody] EmpSalary empSalary)
        {
            _logger.LogInformation("Insert department method started");

            var status = await _empsalary.InsertEmpSalary(empSalary);
            return status;
        }

        /*[HttpPut("UpdateAll/{id}")]
        [Authorize(new[] { "Admin" })]
        // [Route("UpdateAll")]
        public EmpSalary UpdateEmpsalry(int id, string? name, int? requestedcompanyId)
        {
            _logger.LogInformation("Update method started");
            var status = _department.UpdateDepartment(id, name, requestedcompanyId);
            return status;
        }
*/
        [HttpDelete("{id}")]
        [Authorize(new[] { "Admin" })]
        public async Task<bool> DeleteEmpsalary(int id)
        {
            _logger.LogInformation("Delete method started");
            var status = await _empsalary.deleteEmpsalary(id);
            return status;
        }

        [HttpPut("SoftDelete")]
        [Authorize(new[] { "Admin" })]

        public bool SoftDelete(int id, short isActive)
        {
            _logger.LogInformation("Soft update Employee salary method started");
            var res = _empsalary.SoftDelete(id, isActive);
            return res;

        }
    }
}
