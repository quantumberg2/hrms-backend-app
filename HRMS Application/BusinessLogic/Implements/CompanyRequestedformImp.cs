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
                          select row).ToList();
            return result;
        }

        public RequestedCompanyForm GetById(int id)
        {
            var result = (from row in _context.RequestedCompanyForms
                          where row.Id == id
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

        /*public async Task<string> InsertRequestedCompanyForm(RequestedCompanyForm requestedCompanyForm)
        {
            if (!IsValidPhoneNumber(requestedCompanyForm.PhoneNumber))
            {
                return "Invalid phone number. The phone number must be exactly 10 digits.";
            }

            // Set default values
            requestedCompanyForm.InsertedDate = DateTime.UtcNow;
            requestedCompanyForm.UpdatedDate = DateTime.UtcNow;
            requestedCompanyForm.Status = "Requested";

            // Decode the token
            DecodeToken();

            // Check if the email already exists
            var existingCompanyForm = await _context.RequestedCompanyForms
                .FirstOrDefaultAsync(c => c.Email == requestedCompanyForm.Email);

            string generatedOtp;

            if (existingCompanyForm != null)
            {
                // Update the existing record with new OTP and expiration time
                generatedOtp = GenerateOtp();
                existingCompanyForm.GenerateOtp = generatedOtp;
                existingCompanyForm.OtpExpiration = DateTime.UtcNow.AddMinutes(10); // OTP valid for 10 minutes
                existingCompanyForm.UpdatedDate = DateTime.UtcNow;

                // Save the changes to the database
                _context.RequestedCompanyForms.Update(existingCompanyForm);
            }
            else
            {
                // Generate OTP
                generatedOtp = GenerateOtp();
                requestedCompanyForm.GenerateOtp = generatedOtp;
                requestedCompanyForm.OtpExpiration = DateTime.UtcNow.AddMinutes(10); // OTP valid for 10 minutes

                // Add the new entity to the context
                _context.RequestedCompanyForms.Add(requestedCompanyForm);
            }

            // Save the changes to the database
            var result = await _context.SaveChangesAsync(_decodedToken);
            if (result != 0)
            {
                // Send OTP via email
                await SendOtpEmailAsync(requestedCompanyForm.Email, generatedOtp);

                return "OTP sent to the provided email address.";
            }
            else
            {
                throw new DatabaseOperationException("Failed to insert company request data");
            }
        }
*/
        public async Task<string> InsertRequestedCompanyForm(RequestedCompanyForm requestedCompanyForm)
        {
            if (!IsValidPhoneNumber(requestedCompanyForm.PhoneNumber))
            {
                return "Invalid phone number. The phone number must be exactly 10 digits.";
            }

            // Set default values
            requestedCompanyForm.InsertedDate = DateTime.UtcNow;
            requestedCompanyForm.UpdatedDate = DateTime.UtcNow;
            requestedCompanyForm.Status = "Requested";

            // Decode the token
            DecodeToken();

            // Generate OTP
            string generatedOtp = GenerateOtp();

            // Check if the email already exists in the RequestedCompanyForm table
            var existingCompanyForm = await _context.RequestedCompanyForms
                .FirstOrDefaultAsync(c => c.Email == requestedCompanyForm.Email);

            var employeeCredential = await _context.EmployeeCredentials
               .FirstOrDefaultAsync(e => e.Email == requestedCompanyForm.Email);

            if (existingCompanyForm != null)
            {
                // Update the existing record with new OTP and expiration time
                employeeCredential.GenerateOtp = generatedOtp;
                employeeCredential.OtpExpiration = DateTime.UtcNow.AddMinutes(10); // OTP valid for 10 minutes
                existingCompanyForm.UpdatedDate = DateTime.UtcNow;

                // Update the record in the database
                _context.RequestedCompanyForms.Update(existingCompanyForm);
            }
            else
            {
                // Add the new RequestedCompanyForm entity to the context
                employeeCredential.GenerateOtp = generatedOtp;
                employeeCredential.OtpExpiration = DateTime.UtcNow.AddMinutes(10); // OTP valid for 10 minutes

                _context.RequestedCompanyForms.Add(requestedCompanyForm);

                // Save the changes to get the ID for the newly added RequestedCompanyForm
                await _context.SaveChangesAsync(_decodedToken);

                // Retrieve the newly added RequestedCompanyForm with its ID
                existingCompanyForm = await _context.RequestedCompanyForms
                    .FirstOrDefaultAsync(c => c.Email == requestedCompanyForm.Email);
            }

            // Create or update the EmployeeCredential record
            var existingEmployeeCredential = await _context.EmployeeCredentials
                .FirstOrDefaultAsync(e => e.Email == requestedCompanyForm.Email);

            if (existingEmployeeCredential != null)
            {
                // Update the existing EmployeeCredential record with new OTP and default password
                existingEmployeeCredential.GenerateOtp = generatedOtp;
                existingEmployeeCredential.OtpExpiration = DateTime.UtcNow.AddMinutes(10); // OTP valid for 10 minutes
                existingEmployeeCredential.DefaultPassword = true;
                existingEmployeeCredential.Password = GeneratePassword(); // Generate a default password
                existingEmployeeCredential.RequestedCompanyId = existingCompanyForm.Id;

                // Update the record in the database
                _context.EmployeeCredentials.Update(existingEmployeeCredential);
            }
            else
            {
                // Create a new EmployeeCredential record
                var newEmployeeCredential = new EmployeeCredential
                {
                    UserName = requestedCompanyForm.Email, // Use email as username
                    Password = GeneratePassword(), // Generate a default password
                    Email = requestedCompanyForm.Email,
                    DefaultPassword = true,
                    GenerateOtp = generatedOtp,
                    OtpExpiration = DateTime.UtcNow.AddMinutes(10), // OTP valid for 10 minutes
                    RequestedCompanyId = existingCompanyForm.Id,
                    Status = 1 // Assuming 1 means active, change as needed
                };

                _context.EmployeeCredentials.Add(newEmployeeCredential);
            }

            // Save all changes to the database
            var result = await _context.SaveChangesAsync(_decodedToken);
            if (result != 0)
            {
                // Send OTP via email
                await SendOtpEmailAsync(requestedCompanyForm.Email, generatedOtp);

                return "OTP sent to the provided email address.";
            }
            else
            {
                throw new DatabaseOperationException("Failed to insert company request data");
            }
        }

       /* public async Task<string> GenerateAndSendOtp(string email)
        {
            // Check if the email already exists
            var existingCompanyForm = await _context.RequestedCompanyForms
                .FirstOrDefaultAsync(c => c.Email == email);

            var employeeCredential = await _context.EmployeeCredentials
               .FirstOrDefaultAsync(e => e.Email == email);

            string generatedOtp;

            if (existingCompanyForm != null)
            {
                // Update the existing record with new OTP and expiration time
                generatedOtp = GenerateOtp();
                employeeCredential.GenerateOtp = generatedOtp;
                employeeCredential.OtpExpiration = DateTime.UtcNow.AddMinutes(10); // OTP valid for 10 minutes
                existingCompanyForm.UpdatedDate = DateTime.UtcNow;

                // Save the changes to the database
                _context.RequestedCompanyForms.Update(existingCompanyForm);
            }
            else
            {
                return "Email not found.";
            }

            // Save the changes to the database
            var result = await _context.SaveChangesAsync(_decodedToken);
            if (result != 0)
            {
                // Send OTP via email
                var otpEmail = new OtpEmail
                {
                    EmailAddress = email,
                    Otp = generatedOtp
                };
                await _emailService.SendOtpEmailAsync(otpEmail);

                return "OTP sent to the provided email address.";
            }
            else
            {
                throw new DatabaseOperationException("Failed to update company request data.");
            }
        }*/
        private async Task SendOtpEmailAsync(string email, string otp)
        {
            var otpEmail = new OtpEmail
            {
                EmailAddress = email,
                Otp = otp
            };
            await _emailService.SendOtpEmailAsync(otpEmail);
        }
       /* public async Task<string> UpdatePassword(string email, string otp, string newPassword)
        {
            // Check if the email and OTP match and are valid
            var existingCompanyForm = await _context.EmployeeCredentials
                .FirstOrDefaultAsync(c => c.Email == email && c.GenerateOtp == otp);

            if (existingCompanyForm == null || existingCompanyForm.OtpExpiration < DateTime.UtcNow)
            {
                return "Invalid or expired OTP.";
            }

            // Update the password in EmployeeCredentials
            var employeeCredential = await _context.EmployeeCredentials
                .FirstOrDefaultAsync(e => e.Email == email && e.RequestedCompanyId == existingCompanyForm.Id);

            if (employeeCredential == null)
            {
                return "User not found.";
            }

            employeeCredential.Password = newPassword;
*//*            employeeCredential.DefaultPassword = false;
*//*            _context.EmployeeCredentials.Update(employeeCredential);

           
            _context.EmployeeCredentials.Update(existingCompanyForm);

            // Save the changes to the database
            var result = await _context.SaveChangesAsync(_decodedToken);
            if (result != 0)
            {
                return "Password updated successfully.";
            }
            else
            {
                throw new DatabaseOperationException("Failed to update password.");
            }
        }*/

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
