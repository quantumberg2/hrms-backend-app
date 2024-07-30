using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogics.Implements;
using HRMS_Application.Entities;
using HRMS_Application.Models.Users;
using HRMS_Application.Entities;
using HRMS_Application.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Models;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserServiceController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserServiceController> _logger;

        public UserServiceController(IUserService userService, ILogger<UserServiceController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            _logger.LogInformation("Authenticate method started");
            var response = _userService.Authenticate(model);
            return Ok(response);
        }

        [Authorize("Admin")]
        //[AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Get all method started");
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
             _logger.LogInformation("Get by id method started");
            // only admins can access other Employee records
            var currentUser = (EmployeeDetail)HttpContext.Items["User"];
            if (id != currentUser.Id)// && currentUser.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var user = _userService.GetById(id);
            return Ok(user);
        }
    }
}
