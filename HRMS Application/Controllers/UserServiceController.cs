using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogics.Implements;
using HRMS_Application.Entities;
using HRMS_Application.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Models;
using HRMS_Application.DTO;
using System.IdentityModel.Tokens.Jwt;

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

            // Using "as" keyword to safely cast and check for null
            var currentUser = HttpContext.Items["User"] as EmployeeDetail;
            if (currentUser == null)
            {
                return Unauthorized(new { message = "User not found in context" });
            }

            if (id != currentUser.Id) // Add the role check if needed
            {
                return Unauthorized(new { message = "Unauthorized" });
            }

            var user = _userService.GetById(id);
            return Ok(user);
        }


        [HttpPost("select-company")]
        public IActionResult SelectCompany([FromBody] SelectCompanyRequest model)
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var Userid = int.Parse(jwtToken.Claims.First(claim => claim.Type == "UserId").Value);
            var response = _userService.SelectCompany(model,Userid);

            if (response == null)
                return Unauthorized(new { message = "Invalid company selection" });

            return Ok(response);
        }
    }
}
