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


        public CompanyrequestedController(ICompanyRequestedform companyRequested, ILogger<CompanyrequestedController> logger, HRMSContext context)
        {
            _companyRequested = companyRequested;
            _logger = logger;
            _context = context;
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
        public IActionResult InsertRequestedCompanyForm([FromBody] RequestedCompanyForm requestedCompanyForm)
        {
            try
            {
                // Call the synchronous version of InsertRequestedCompanyForm
                _companyRequested.InsertRequestedCompanyForm(requestedCompanyForm);
                return Ok(new { message = "Otp sent to the Provided Email ID" });
            }
            catch (EmailAlreadyExistsException ex)
            {
                // Log the specific email conflict exception
                Console.WriteLine($"Email conflict error: {ex.Message}");
                return Conflict(new { status = "Error", message = ex.Message });
            }
            catch (Exception ex)
            {
                // Log the full exception details to help debug the issue
                Console.WriteLine($"An internal server error occurred: {ex.Message}");
                Console.WriteLine(ex.StackTrace);  // Log stack trace to see where the error is coming from

                // Return a generic 500 Internal Server Error status
                return StatusCode(500, new { status = "Error", message = "An internal server error occurred." });
            }
        }


        [HttpPut("SoftDelete")]
        [Authorize(new[] { "Admin" })]

        public bool SoftDelete(int id, short isActive)
        {
            _logger.LogInformation("Soft update company request method started");
            var res = _companyRequested.SoftDelete(id, isActive);
            return res;

        }

        [HttpPost]
        [Route("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] OtpEmail request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.EmailAddress) || string.IsNullOrWhiteSpace(request.Otp))
            {
                return BadRequest("Invalid request data.");
            }

            var companyForm = await _context.RequestedCompanyForms
                .FirstOrDefaultAsync(c => c.Email == request.EmailAddress);

            var employeeCredential = await _context.EmployeeCredentials
                .FirstOrDefaultAsync(e => e.Email == request.EmailAddress);

            if (companyForm == null)
            {
                return NotFound(new { Status = "Error", Message = "Company form not found." });
            }

            if (employeeCredential == null)
            {
                return NotFound(new { Status = "Error", Message = "Employee credential not found." });
            }

            var storedOtp = employeeCredential.GenerateOtp.Trim().ToLower();
            var providedOtp = request.Otp.Trim().ToLower();

            // Log the OTP values using ILogger
            _logger.LogInformation($"Stored OTP: {storedOtp}");
            _logger.LogInformation($"Provided OTP: {providedOtp}");

            if (storedOtp != providedOtp)
            {
                await UpdateCompanyFormStatus(companyForm, "Rejected");
                return BadRequest(new { Status = "Error", Message = "Invalid OTP." });
            }

            if (employeeCredential.OtpExpiration < DateTime.UtcNow)
            {
                await UpdateCompanyFormStatus(companyForm, "Expired");
                return BadRequest(new { Status = "Error", Message = "OTP has expired." });
            }

            await UpdateCompanyFormStatus(companyForm, "Verified");

            // Optionally send a confirmation email or message here

            return Ok(new { Status = "Success", Message = "Received your request. Admin will get back to you shortly." });
        }

        private async Task UpdateCompanyFormStatus(RequestedCompanyForm companyForm, string status)
        {
            companyForm.Status = status;
            _context.RequestedCompanyForms.Update(companyForm);
            await _context.SaveChangesAsync();
        }


    }

}
public class OtpRequest
{
    public string? Email { get; set; }
}




