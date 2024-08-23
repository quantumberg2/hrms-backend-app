using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Authorization;
using System.Xml.Linq;
using HRMS_Application.DTO;
using HRMS_Application.Middleware.Exceptions;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpCredentialController : ControllerBase
    {
        private readonly IEmpCredential _empCredential;
        private readonly ILogger<EmpCredentialController> _logger;
        public EmpCredentialController(IEmpCredential empCredential, ILogger<EmpCredentialController> logger)
        {
            _empCredential = empCredential;
            _logger = logger;
        }
        [HttpGet]
        [Authorize(new[] { "Admin" })]
        public List<EmployeeCredential> GetEmpCredential()
        {
            _logger.LogInformation("Get All Employee Credential started");
            var result = _empCredential.GetAllEmpCredential();
            return result;

        }
        [HttpGet("GetById")]
        public EmployeeCredential GetEmployeeCredentialsById(int id)
        {
            _logger.LogInformation("Getby ID for Employee Credential method started");
            var result = _empCredential.GetById(id);
            return result;
        }

        [HttpDelete]
        [Authorize(new[] { "Admin" })]
        public async Task<bool> DeleteEmpCredential(int id)
        {
            _logger.LogInformation("Delete Employee Credential method was started");
            var result = await _empCredential.DeleteEmployeeCredential(id);
            return result;
        }
        [HttpPost]
        //[Authorize(new[] { "Admin" })]
        public async Task<string> InsertemployeeCredential([FromBody] EmployeeCredential employeeCredential)
        {
            _logger.LogInformation("Insert Employee Credential method started");
            var result = await _empCredential.InsertEmployeeCredential(employeeCredential);
                return result;

        }
        [HttpPut]
        [Authorize(new[] { "Admin" })]
        public async Task<EmployeeCredential> updateemployeecredential(int id, string? username, string? password, short? status, int? requestedCompanyId)
        {
            _logger.LogInformation("Update method started");
            var result = await _empCredential.UpdateEmployeeCredentials(id, username,password,status,requestedCompanyId);
            return result;
        }
        [HttpPost("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request cannot be null.");
            }

            var result = await _empCredential.UpdateEmployeePassword(request.Email, request.OldPassword, request.NewPassword);

            if (result == "Password updated successfully.")
            {
                return Ok(new { Message = result });
            }
            else
            {
                return BadRequest(new { Message = result });
            }
        }
        [HttpPost("generate-otp")]
        public async Task<IActionResult> GenerateAndSendOtp([FromBody] OtpRequest otpRequest)
        {
            if (otpRequest == null || string.IsNullOrEmpty(otpRequest.Email))
            {
                return BadRequest("Email is required.");
            }

            try
            {
                var result = await _empCredential.GenerateAndSendOtp(otpRequest.Email);
                return Ok(new { message = result });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (DatabaseOperationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpPost("Forgot-Password")]
        public async Task<IActionResult> UpdatePassword([FromBody] ForgotpasswordRequest updatePasswordRequest)
        {
            if (updatePasswordRequest == null || string.IsNullOrEmpty(updatePasswordRequest.Email) ||
                string.IsNullOrEmpty(updatePasswordRequest.Otp) || string.IsNullOrEmpty(updatePasswordRequest.NewPassword) || string.IsNullOrEmpty(updatePasswordRequest.ConfirmPassword))
            {
                return BadRequest("Email, OTP, and new password are required.");
            }

            try
            {
                var result = await _empCredential.UpdatePassword(updatePasswordRequest.Email, updatePasswordRequest.Otp, updatePasswordRequest.NewPassword, updatePasswordRequest.ConfirmPassword);
                return Ok(new { message = result });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (DatabaseOperationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

    }
}
