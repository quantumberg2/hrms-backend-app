using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Authorization;
namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoles _roles;
        private readonly ILogger<RolesController> _logger;


        public RolesController(IRoles roles, ILogger<RolesController> logger)
        {
            _roles = roles;
            _logger = logger;
        }
        [HttpGet]
        //[Authorize(new[] { "Admin", "Developer" })]
        public List<Role> GetAllRole()
        {
            _logger.LogInformation("Get all department method started");
            var dept = _roles.GetAllRoles();
            return dept;
        }

        [HttpPost("insertEmployees")]
        [Authorize(new[] { "Admin" })]
        public async Task<string> InsertRoles([FromBody] Role role)
        {
            _logger.LogInformation("Insert department method started");

            var status = await _roles.InsertRole(role);
            return status;
        }

       /* [HttpPut("UpdateAll/{id}")]
        [Authorize(new[] { "Admin" })]
        // [Route("UpdateAll")]
        public Department UpdateDepartment(int id, string? name, int? requestedcompanyId)
        {
            _logger.LogInformation("Update method started");
            var status = _department.UpdateDepartment(id, name, requestedcompanyId);
            return status;
        }*/

        [HttpDelete("{id}")]
        [Authorize(new[] { "Admin" })]
        public async Task<bool> DeleteRole(int id)
        {
            _logger.LogInformation("Delete method started");
            var status = await _roles.deleteRole(id);
            return status;
        }

        [HttpPut("SoftUpdate")]
        [Authorize(new[] { "Admin" })]

        public bool SoftDelete(int id, short isActive)
        {
            _logger.LogInformation("Soft update Roles method started");
            var res = _roles.SoftDelete(id, isActive);
            return res;

        }
    }
}
