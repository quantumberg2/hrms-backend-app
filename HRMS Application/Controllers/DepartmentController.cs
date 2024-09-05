using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Authorization;


namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _department;
        private readonly ILogger<DepartmentController> _logger;


        public DepartmentController(IDepartment department, ILogger<DepartmentController> logger)
        {
            _department = department;
            _logger = logger;
        }
        [HttpGet]
        //[Authorize(new[] { "Admin", "Developer" })]
        public List<Department> GetAllDepartments()
        {
            _logger.LogInformation("Get all department method started");
            var dept = _department.GetAllDepartment();
            return dept;
        }

        [HttpGet("GetDeptByName")]
        public List<Department> GetDepartmentsByName(string name)
        {
            _logger.LogInformation("Get dept info by name method started");
            var res = _department.GetDepartmentsByName(name);
            return res;
        }

        [HttpPost("insertEmployees")]
        [Authorize(new[] { "Admin" })]
        public async Task<string> InsertDepartments([FromBody] Department department)
        {
            _logger.LogInformation("Insert department method started");

            var status = await _department.InsertDepartment(department);
            return status;
        }

        [HttpPut("UpdateAll/{id}")]
        [Authorize(new[] { "Admin" })]
        // [Route("UpdateAll")]
        public async Task<Department> UpdateDepartment(int id, string? name, int? requestedcompanyId)
        {
            _logger.LogInformation("Update method started");
            var status = await _department.UpdateDepartment(id, name, requestedcompanyId);
            return status;
        }
                                    
        [HttpDelete("{id}")]
        [Authorize(new[] { "Admin" })]
        public async Task<bool> DeleteDepartment(int id)
        {
          
            _logger.LogInformation("Delete method started");
            var status = await _department.deleteDepartment(id);
            return status;
        }

        [HttpPut("SoftUpdate")]
        [Authorize(new[] { "Admin" })]

        public bool SoftDelete(int id, short isActive)
        {
            _logger.LogInformation("Soft update department method started");
            var res = _department.SoftDelete(id, isActive);
            return res;

        }
    }
}
