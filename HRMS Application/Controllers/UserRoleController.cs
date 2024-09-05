using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Authorization;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoles _userRole;
        private readonly ILogger<UserRoleController> _logger;


        public UserRoleController(IUserRoles userRoles, ILogger<UserRoleController> logger)
        {
            _userRole = userRoles;
            _logger = logger;
        }
        [HttpGet]
        //[Authorize(new[] { "Admin", "Developer" })]
        public List<UserRolesJ> GetAllUserRoles()
        {
            _logger.LogInformation("Get all department method started");
            var dept = _userRole.GetAlluserRole();
            return dept;
        }

        [HttpPost("insertEmployees")]
        [Authorize(new[] { "Admin" })]
        public async Task<string> InsertUserRole([FromBody] UserRolesJ userRole)
        {
            _logger.LogInformation("Insert department method started");

            var status = await _userRole.InsertuserRoles(userRole);
            return status;
        }

      /*  [HttpPut("UpdateAll/{id}")]
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
        public async Task<bool> DeleteUserRole(int id)
        {
            _logger.LogInformation("Delete method started");
            var status = await _userRole.deleteUserRole(id);
            return status;
        }

        [HttpPut("SoftUpdate")]
        [Authorize(new[] { "Admin" })]

        public bool SoftDelete(int id, short isActive)
        {
            _logger.LogInformation("Soft update user roles method started");
            var res = _userRole.SoftDelete(id, isActive);
            return res;

        }
    }
}
