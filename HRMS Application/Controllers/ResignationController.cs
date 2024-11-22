using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResignationController : ControllerBase
    {
       private readonly ILogger<ResignationController> _logger;
       private readonly IResignation _resignation;

        public ResignationController(ILogger<ResignationController> logger, IResignation resignation)
        {
            _logger = logger;
            _resignation = resignation;
        }

        [HttpGet]
        public List<Resignation> GetData()
        {
            _logger.LogInformation("Get resignation data method started");
            var res = _resignation.GetData();
            return res;
        }

        [HttpGet("GetResignationStatus")]
        public async Task<IActionResult> GetAllResignationStatus()
        {
            _logger.LogInformation("Get all resignation data method started");

            try
            {
                var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer", "").Trim();

                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Authorization token is missing or invalid.");
                }

                var handler = new JwtSecurityTokenHandler();
                if (!handler.CanReadToken(token))
                {
                    return Unauthorized("Invalid token format.");
                }

                var jwtToken = handler.ReadJwtToken(token);
                var employeeCredentialIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;

                if (string.IsNullOrEmpty(employeeCredentialIdClaim) || !int.TryParse(employeeCredentialIdClaim, out var employeeCredentialId))
                {
                    return Unauthorized("Employee credential ID not found or invalid in the token.");
                }

                var res = _resignation.GetAllResignationStatus(employeeCredentialId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetAllResignationsForGrid")]
        [Authorize(new[] { "Admin" })]
        public async Task<IActionResult> GetResignationDetailsforGrid()
        {
            _logger.LogInformation("Resignation initiate and approve method initiated");
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer", "").Trim();

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Authorization token is missing or invalid.");
            }


            var handler = new JwtSecurityTokenHandler();
            if (!handler.CanReadToken(token))
            {
                return Unauthorized("Invalid token format.");
            }

            var jwtToken = handler.ReadJwtToken(token);
            var employeeCredentialIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;

            if (string.IsNullOrEmpty(employeeCredentialIdClaim) || !int.TryParse(employeeCredentialIdClaim, out var employeeCredentialId))
            {
                return Unauthorized("Employee credential ID not found or invalid in the token.");
            }

            var res = _resignation.GetResignationDetailsforGrid();
            return Ok(res);

        }



        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> InsertResignation([FromBody] ResignationDTO resignation)
        {
            _logger.LogInformation("Insert resignation data method started");

            try
            {
                var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer", "").Trim();

                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Authorization token is missing or invalid.");
                }


                var handler = new JwtSecurityTokenHandler();
                if (!handler.CanReadToken(token))
                {
                    return Unauthorized("Invalid token format.");
                }

                var jwtToken = handler.ReadJwtToken(token);
                var employeeCredentialIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;

                if (string.IsNullOrEmpty(employeeCredentialIdClaim) || !int.TryParse(employeeCredentialIdClaim, out var employeeCredentialId))
                {
                    return Unauthorized("Employee credential ID not found or invalid in the token.");
                }

                var res = _resignation.InsertResignation(employeeCredentialId, resignation); 
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public string UpdateResignation(Resignation resignation)
        {
            _logger.LogInformation("Update resignation method started");
            var res = _resignation.UpdateResignation(resignation);
            return res;
        }

        [HttpPut("SoftDelete")]
        public bool SoftDeleteResignation(int id, short isActive)
        {
            _logger.LogInformation("Soft delete method started");
            var res = _resignation.SoftDeleteResignation(id, isActive);
            return res;
        }

        [HttpPut("AdminApproval")]
        [Authorize(new[] { "Admin" })]
        public async Task<IActionResult> ResignationUpdateByAdmin(int id,AdminResignationApprovalDTO resignation)
        {
            _logger.LogInformation("Resignation initiate and approve method initiated");
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "").Trim();

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Authorization header is missing or token is empty.");
            }

            var handler = new JwtSecurityTokenHandler();
            if (!handler.CanReadToken(token))
            {
                return Unauthorized("Invalid token format.");
            }

            var jwtToken = handler.ReadJwtToken(token);
            var employeeCredentialIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;

            if (string.IsNullOrEmpty(employeeCredentialIdClaim) || !int.TryParse(employeeCredentialIdClaim, out var empCredId))
            {
                return Unauthorized("Employee credential ID not found or invalid in the token.");
            }


            var res = _resignation.ResignationUpdateByAdmin(empCredId,id, resignation);
                return Ok(res);
     
        }

        [HttpPut("StatusUpdate")]
        [Authorize(new[] { "Admin", "User" })]
        public async Task<IActionResult> UpdateResignationStatus(int id, string newStatus)
        {
            _logger.LogInformation("Update new resignation status method started");

            try
            {
                var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "").Trim();

                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Authorization header is missing or token is empty.");
                }

                var handler = new JwtSecurityTokenHandler();
                if (!handler.CanReadToken(token))
                {
                    return Unauthorized("Invalid token format.");
                }

                var jwtToken = handler.ReadJwtToken(token);
                var employeeCredentialIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;

                if (string.IsNullOrEmpty(employeeCredentialIdClaim) || !int.TryParse(employeeCredentialIdClaim, out var empCredId))
                {
                    return Unauthorized("Employee credential ID not found or invalid in the token.");
                }

                var resignation =  _resignation.UpdateResignationStatus(empCredId, id, newStatus);

                if (resignation == null)
                {
                    return NotFound("Leave record not found.");
                }

                return Ok(resignation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpGet("GetResignationbyStatus/{status}")]
        [AllowAnonymous]
        public async Task<ActionResult<ResignationGridDTO>> GetResignationInfoByStatus(string status)
        {
            _logger.LogInformation("Get all Resignations by status method started");
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "").Trim();

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Authorization header is missing or token is empty.");
            }

            var handler = new JwtSecurityTokenHandler();
            if (!handler.CanReadToken(token))
            {
                return Unauthorized("Invalid token format.");
            }

            var jwtToken = handler.ReadJwtToken(token);
            var employeeCredentialIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;

            if (string.IsNullOrEmpty(employeeCredentialIdClaim) || !int.TryParse(employeeCredentialIdClaim, out var empCredId))
            {
                return Unauthorized("Employee credential ID not found or invalid in the token.");
            }

            var resignations = _resignation.GetResignationInfoByStatus(status, empCredId);

            if (resignations == null || !resignations.Any())
            {
                return NotFound("No resignations found.");
            }

            return Ok(resignations);
        }
    }
}
