using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.IdentityModel.Tokens.Jwt;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResignationApprovalController : ControllerBase
    {
        private readonly ILogger<ResignationApprovalController> _logger;
        private readonly IResignationApproval _resignationApproval;

        public ResignationApprovalController(ILogger<ResignationApprovalController> logger, IResignationApproval resignationApproval)
        {
            _logger = logger;
            _resignationApproval = resignationApproval;
        }

        [HttpGet]
        public List<ResignationApprovalStatus> GetData()
        {
            _logger.LogInformation("Get Resignation approval data method started");
            var res = _resignationApproval.GetData();
            return res;
        }

        [HttpPost]
        public string InsertResignation(ResignationApprovalStatus resignation)
        {
            _logger.LogInformation("Insert resignation approval data method started");
            var res = _resignationApproval.InsertResignation(resignation);
            return res;
        }

        [HttpPut]
        public string UpdateResignation(ResignationApprovalStatus resignation)
        {
            _logger.LogInformation("Update resignation approval method started");
            var res = _resignationApproval.UpdateResignation(resignation);
            return res;
        }

        [HttpPut("SoftDelete")]
        public bool SoftDeleteResignation(int id, short isActive)
        {
            _logger.LogInformation("Soft delete method started");
            var res = _resignationApproval.SoftDeleteResignation(id, isActive);
            return res;
        }

        [HttpPut("AdminApproval")]
        [Authorize(new[] { "Admin" })]
        public async Task<IActionResult> UpdateAdminApprovalStatus(int id, string adminApprovalStatus)
        {
            _logger.LogInformation("Admin approval for resignation method initiated");
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
            var roleClaims = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "Roles")?.Value;

            if (string.IsNullOrEmpty(roleClaims))
            {
                return Unauthorized("Roles claim not found in the token.");
            }

                var res = _resignationApproval.UpdateAdminApprovalStatus(id, adminApprovalStatus);
                return Ok(res);
        }

        [HttpPut("ManagerApproval")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateManagerApprovalStatus(int id, string managerApprovalstatus)
        {
            _logger.LogInformation("Admin approval for resignation method initiated");
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
     
                var res = _resignationApproval.UpdateManagerApprovalStatus(empCredId, id, managerApprovalstatus);
                return Ok(res);
        }
    }
}
