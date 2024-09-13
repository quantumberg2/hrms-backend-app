using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Middleware.Exceptions;
using HRMS_Application.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Linq;
using System.Threading.Tasks;
using UnlimitSoft.Message;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class CompanyRequestedformImp : ICompanyRequestedform
    {
        private readonly HRMSContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtUtils _jwtUtils;
        public List<string>? dToken;
        private int? _decodedToken;
        private readonly IEmailService _emailService;

        public CompanyRequestedformImp(HRMSContext context, IHttpContextAccessor httpContextAccessor, IJwtUtils jwtUtils, IEmailService emailService)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _jwtUtils = jwtUtils;
            _emailService = emailService;
        }

        private void DecodeToken()
        {
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (string.IsNullOrEmpty(token))
            {
                dToken = null;
            }
            else
            {
                var userId = _jwtUtils.ValidateJwtToken(token);
                if (userId.HasValue)
                {
                    var userDetails = _context.EmployeeCredentials.FirstOrDefault(e => e.Id == userId.Value);
                    if (userDetails != null)
                    {
                        _decodedToken = userDetails.Id;
                        dToken = userDetails.UserRolesJs.Select(ur => ur.Roles.Name).ToList(); // Assuming you want role names
                    }
                    else
                    {
                        // Handle the case where the user is not found in the database
                        dToken = null;
                    }
                }
            }
        }
        public bool SoftDelete(int id, short isActive)
        {
            var res = (from row in _context.RequestedCompanyForms
                       where row.Id == id
                       select row).FirstOrDefault();
            if (res != null)
            {
                res.IsActive = isActive;
                _context.RequestedCompanyForms.Update(res);
                _context.SaveChanges();
                return true;

            }
            return false;
        }

        public async Task<bool> DeleteRequestedCompanyForm(int id)
        {
            DecodeToken();
            var result = await (from row in  _context.RequestedCompanyForms
                          where row.Id == id
                          select row).SingleOrDefaultAsync();
              _context.RequestedCompanyForms.Remove(result);
            await _context.SaveChangesAsync(_decodedToken);
            return true;
        }

        public List<RequestedCompanyForm> GetAllRequestedCompanyForm()
        {
            var result = (from row in _context.RequestedCompanyForms
                          where  row.IsActive == 1
                          select row).ToList();
            return result;
        }

        public RequestedCompanyForm GetById(int id)
        {
            var result = (from row in _context.RequestedCompanyForms
                          where row.Id == id && row.IsActive == 1
                          select row).SingleOrDefault();
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new NotFoundException($"Employee Credential Id '{id}' is not found");
            }
        }

       
        public async Task<string> InsertRequestedCompanyForm(RequestedCompanyForm requestedcompanyform)
        {
            if (!IsValidPhoneNumber(requestedcompanyform.PhoneNumber))
            {
                return "Invalid phone number. The phone number must be exactly 10 digits.";
            }

            // Set default values
            requestedcompanyform.InsertedDate = DateTime.UtcNow;
            requestedcompanyform.UpdatedDate = DateTime.UtcNow;
            requestedcompanyform.Status = "Requested";

            // Decode the token
            DecodeToken();

            // Generate OTP
            string generatedOtp = GenerateOtp();

            // Check if the email already exists in the RequestedCompanyForm table
            var existingCompanyForm = await _context.RequestedCompanyForms
                .FirstOrDefaultAsync(c => c.Email == requestedcompanyform.Email);

            if (existingCompanyForm != null)
            {
                // Update the existing record with new OTP and expiration time
                existingCompanyForm.UpdatedDate = DateTime.UtcNow;

                // Update the record in the database
                _context.RequestedCompanyForms.Update(existingCompanyForm);
            }
            else
            {
                // Add the new RequestedCompanyForm entity to the context
                await _context.RequestedCompanyForms.AddAsync(requestedcompanyform);
                await _context.SaveChangesAsync(_decodedToken); // Save the new RequestedCompanyForm

                // Retrieve the newly added RequestedCompanyForm with its ID
                existingCompanyForm = requestedcompanyform; // Now it has a valid ID
            }

            // Handle the EmployeeCredential record
            var existingEmployeeCredential = await _context.EmployeeCredentials
                .FirstOrDefaultAsync(e => e.Email == requestedcompanyform.Email);

            if (existingEmployeeCredential != null)
            {
                // Update the existing EmployeeCredential record
                existingEmployeeCredential.GenerateOtp = generatedOtp;
                existingEmployeeCredential.OtpExpiration = DateTime.UtcNow.AddMinutes(10); // OTP valid for 10 minutes
                existingEmployeeCredential.DefaultPassword = true;
                existingEmployeeCredential.Password = GeneratePassword(); // Generate a default password
                existingEmployeeCredential.RequestedCompanyId = existingCompanyForm.Id;

                _context.EmployeeCredentials.Update(existingEmployeeCredential);
            }
            else
            {
                // Create a new EmployeeCredential record
                var newEmployeeCredential = new EmployeeCredential
                {
                    UserName = requestedcompanyform.Email, // Use email as username
                    Password = GeneratePassword(), // Generate a default password
                    Email = requestedcompanyform.Email,
                    DefaultPassword = true,
                    GenerateOtp = generatedOtp,
                    OtpExpiration = DateTime.UtcNow.AddMinutes(10), // OTP valid for 10 minutes
                    RequestedCompanyId = existingCompanyForm.Id,
                    Status = 1 // Assuming 1 means active, change as needed
                };

                await _context.EmployeeCredentials.AddAsync(newEmployeeCredential);
            }

            // Save all changes to the database
            var result = await _context.SaveChangesAsync(_decodedToken);
            if (result != 0)
            {
                // Send OTP via email
                await SendOtpEmailAsync(requestedcompanyform.Email, generatedOtp);

                return "OTP sent to the provided email address.";
            }
            else
            {
                throw new DatabaseOperationException("Failed to insert company request data");
            }
        }

        private async Task SendOtpEmailAsync(string email, string otp)
        {
            var otpEmail = new OtpEmail
            {
                EmailAddress = email,
                Otp = otp
            };
            await _emailService.SendOtpEmailAsync(otpEmail);
        }
     
        private string GenerateOtp()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString(); // Generate a 6-digit OTP
        }
        private string GeneratePassword(int length = 12)
        {
            const string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@";
            var random = new Random();
            return new string(Enumerable.Repeat(validChars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return !string.IsNullOrEmpty(phoneNumber) && phoneNumber.All(char.IsDigit) && phoneNumber.Length == 10;
        }

    }
}
