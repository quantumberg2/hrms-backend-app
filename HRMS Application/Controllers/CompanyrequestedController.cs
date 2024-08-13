using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRMS_Application.Authorization;
using Microsoft.EntityFrameworkCore;
using HRMS_Application.DTO;
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

            if (companyForm == null)
            {
                return NotFound("Company form not found.");
            }

            var storedOtp = companyForm.GenerateOtp.Trim().ToLower();
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

            if (companyForm.OtpExpiration < DateTime.UtcNow)
            {
                companyForm.Status = "Expired";
                _context.RequestedCompanyForms.Update(companyForm);
                await _context.SaveChangesAsync();

                return BadRequest("OTP has expired.");
            }

            companyForm.Status = "Verified";
            _context.RequestedCompanyForms.Update(companyForm);
            await _context.SaveChangesAsync();
            if (companyForm.Status == "Verified")
            {
                // Create and save EmployeeCredential if status is Verified
                var employeeCredential = new EmployeeCredential
                {
                    UserName = companyForm.Name,
                    Email = companyForm.Email,
                    Password = GeneratePassword(),
                    DefaultPassword = true,
                    RequestedCompanyId = companyForm.Id,
                    Status = 1,
                };

                _context.EmployeeCredentials.Add(employeeCredential);
                await _context.SaveChangesAsync();
            }

            return Ok("New company request Is Verified.");
        }

        private string GeneratePassword()
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var res = new char[8];
            var rnd = new Random();
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = valid[rnd.Next(valid.Length)];
            }
            return new string(res);
        }
    }
}
