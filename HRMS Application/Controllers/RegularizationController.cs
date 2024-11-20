using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using HRMS_Application.Authorization;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegularizationController : ControllerBase
    {
        private readonly IRegularization _regularization;
        private readonly ILogger<RegularizationController> _logger;

        public RegularizationController(IRegularization regularization, ILogger<RegularizationController> logger)
        {
            _regularization = regularization;
            _logger = logger;
        }

        [HttpGet("pending-leaves")]
        public IActionResult GetPendingRegularization(string status)
        {
            _logger.LogInformation("Apply leave method started");

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

                if (string.IsNullOrEmpty(employeeCredentialIdClaim) || !int.TryParse(employeeCredentialIdClaim, out var employeeCredentialId))
                {
                    return Unauthorized("Employee credential ID not found or invalid in the token.");
                }

                var pendingLeaves = _regularization.GetPendingRegularization(employeeCredentialId,status);

                return Ok(pendingLeaves);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching pending leaves");
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        [HttpGet("Regularization/{status}")]
        [AllowAnonymous]
        public async Task<ActionResult<List<LeaveApprovalDTO>>> GetLeavesByStatus(string status)
        {
            _logger.LogInformation("Get leaves by status method started");

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

            if (string.IsNullOrEmpty(employeeCredentialIdClaim) || !int.TryParse(employeeCredentialIdClaim, out var managerId))
            {
                return Unauthorized("Employee credential ID not found or invalid in the token.");
            }

            var leaves = await _regularization.GetRegularizationByStatusAsync(status, managerId);

            if (leaves == null || !leaves.Any())
            {
                return NotFound("No leave records found with the given status.");
            }

            return Ok(leaves);
        }
        [HttpGet("History-Regularization")]
        public IActionResult Historyleaves()
        {
            _logger.LogInformation("History Regularization method started");

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

                if (string.IsNullOrEmpty(employeeCredentialIdClaim) || !int.TryParse(employeeCredentialIdClaim, out var employeeCredentialId))
                {
                    return Unauthorized("Employee credential ID not found or invalid in the token.");
                }

                var pendingLeaves = _regularization.GetHistoryRegularization(employeeCredentialId);

                return Ok(pendingLeaves);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching History Regularization");
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
