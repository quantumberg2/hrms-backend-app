using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Authorization;
using Microsoft.EntityFrameworkCore;
using HRMS_Application.DTO;
using HRMS_Application.Middleware.Exceptions;
namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyrequestedController : ControllerBase
    {
        private readonly ICompanyRequestedform _companyRequested;
        private readonly ILogger<CompanyrequestedController> _logger;
        private readonly HRMSContext _context;
        private readonly IEmailPassword _emailPasswordService;


        public CompanyrequestedController(ICompanyRequestedform companyRequested, ILogger<CompanyrequestedController> logger, HRMSContext context, IEmailPassword emailPasswordService)
        {
            _companyRequested = companyRequested;
            _logger = logger;
            _context = context;
            _emailPasswordService = emailPasswordService;
        }
        [HttpGet]
        // [Authorize(new[] { "Admin" })]
        public List<RequestedCompanyForm> GetEmpCredential()
        {
            _logger.LogInformation("Get All Employee Credential started");
            var result = _companyRequested.GetAllRequestedCompanyForm();
            return result;

        }
        [HttpGet("GetById")]
        public RequestedCompanyForm GetEmployeeCredentialsById(int id)
        {
            _logger.LogInformation("Getby ID for Employee Credential method started");
            var result = _companyRequested.GetById(id);
            return result;
        }

        [HttpDelete]
        //[Authorize(new[] { "Admin" })]
        public async Task<bool> DeleteRequestedCompanyForm(int id)
        {
            _logger.LogInformation("Delete Employee Credential method was started");
            var result = await _companyRequested.DeleteRequestedCompanyForm(id);
            return result;
        }
        [HttpPost]
        //[Authorize(new[] { "Admin" })]
        public async Task<string> InsertRequestedCompanyForm([FromBody] RequestedCompanyForm requestedCompanyForm)
        {
            _logger.LogInformation("Insert Employee Credential method started");
            var result = await _companyRequested.InsertRequestedCompanyForm(requestedCompanyForm);
            return result;

        }
        [HttpPost]
        [Route("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] OtpEmail request)
        {
            var companyForm = await _context.RequestedCompanyForms
                .FirstOrDefaultAsync(c => c.Email == request.EmailAddress);

            var employeeCredential = await _context.EmployeeCredentials
                .FirstOrDefaultAsync(e => e.Email == request.EmailAddress);

            if (companyForm == null)
            {
                return NotFound("Company form not found.");
            }

            var storedOtp = employeeCredential.GenerateOtp.Trim().ToLower();
            var providedOtp = request.Otp.Trim().ToLower();

            // Log the OTP values
            Console.WriteLine($"Stored OTP: {storedOtp}");
            Console.WriteLine($"Provided OTP: {providedOtp}");

            if (storedOtp != providedOtp)
            {
                companyForm.Status = "Rejected";
                _context.RequestedCompanyForms.Update(companyForm);
                await _context.SaveChangesAsync();

                return BadRequest("Invalid OTP.");
            }

            if (employeeCredential.OtpExpiration < DateTime.UtcNow)
            {
                companyForm.Status = "Expired";
                _context.RequestedCompanyForms.Update(companyForm);
                await _context.SaveChangesAsync();

                return BadRequest("OTP has expired.");

            }
            companyForm.Status = "Verified";
            _context.RequestedCompanyForms.Update(companyForm);
            await _context.SaveChangesAsync();

            // Retrieve or generate the username and password
            var employeeCredentials = await _context.EmployeeCredentials
                .FirstOrDefaultAsync(e => e.Email == request.EmailAddress);

            if (employeeCredentials == null)
            {
                return NotFound("Employee credential not found.");
            }

            // Send email with username and password
            await _emailPasswordService.SendOtpEmailAsync(new Generatepassword
            {
                EmailAddress = employeeCredential.Email,
                Password = employeeCredential.Password,
                UserName = employeeCredential.UserName
            });

            return Ok("New company request is verified and email sent with credentials.");
        }


        /*[HttpPost("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] ForgotpasswordRequest updatePasswordRequest)
        {
            if (updatePasswordRequest == null || string.IsNullOrEmpty(updatePasswordRequest.Email) ||
                string.IsNullOrEmpty(updatePasswordRequest.Otp) || string.IsNullOrEmpty(updatePasswordRequest.NewPassword))
            {
                return BadRequest("Email, OTP, and new password are required.");
            }

            try
            {
                var result = await _companyRequested.UpdatePassword(updatePasswordRequest.Email, updatePasswordRequest.Otp, updatePasswordRequest.NewPassword);
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
        }*/
    }

}
public class OtpRequest
{
    public string Email { get; set; }
}




