using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using HRMS_Application.Middleware.Exceptions;
using System.Xml.Linq;
using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogics.Interface;
using Microsoft.EntityFrameworkCore;
using HRMS_Application.DTO;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class EmpCredentialImp : IEmpCredential
    {
        private readonly HRMSContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailPassword _emailService;
        private readonly IEmailService _emailotpService;


        private readonly IJwtUtils _jwtUtils;
        private List<string>? dToken;
        private int? _decodedToken;
        public EmpCredentialImp(HRMSContext context, IHttpContextAccessor httpContextAccessor, IJwtUtils jwtUtils, IEmailPassword emailService, IEmailService emailotpService)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _jwtUtils = jwtUtils;
            _emailService = emailService;
            _emailotpService = emailotpService;
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
        public async Task<bool> DeleteEmployeeCredential(int id)
        {
            var result = await (from row in _context.EmployeeCredentials
                          where row.Id == id
                          select row).SingleOrDefaultAsync();
            _context.EmployeeCredentials.Remove(result);
            await _context.SaveChangesAsync(_decodedToken);
            return true;
            
        }

        public List<EmployeeCredential> GetAllEmpCredential()
        {
            var result = (from row in _context.EmployeeCredentials
                          where row.IsActive == 1
                          select row).ToList();
            return result;
            
        }

        public EmployeeCredential GetById(int id)
        {
            var result = (from row in _context.EmployeeCredentials
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

        public async Task<string> InsertEmployeeCredential(EmployeeCredential employeeCredential)
        {
            // Check if the username or email already exists
            var existingUserName = await _context.EmployeeCredentials
                .FirstOrDefaultAsync(e => e.UserName == employeeCredential.UserName);
            var existingEmail = await _context.EmployeeCredentials
                .FirstOrDefaultAsync(e => e.Email == employeeCredential.Email);

            if (existingUserName != null)
            {
                return "Username is not available.";
            }

            if (existingEmail != null)
            {
                return "Email is already in use.";
            }

            // Generate and set the password
            employeeCredential.Password = GeneratePassword();

            // Set DefaultPassword to true
            employeeCredential.DefaultPassword = true;

            // Add the entity to the context
            await _context.EmployeeCredentials.AddAsync(employeeCredential);

            // Save the changes to the database
            var result = await _context.SaveChangesAsync(_decodedToken);
            if (result != 0)
            {
                // Prepare the email details
                var generatepassword = new Generatepassword
                {
                    EmailAddress = employeeCredential.Email,
                    UserName = employeeCredential.UserName,
                    Password = employeeCredential.Password
                };

                // Send the email
                await _emailService.SendOtpEmailAsync(generatepassword);

                return "New Employee Credentials inserted successfully";
            }
            else
            {
                throw new DatabaseOperationException("Failed to insert Employee credential data");
            }
        }

        public async Task<EmployeeCredential> UpdateEmployeeCredentials(int id, string? username, string? password, short? status, int? requestedCompanyId)
        {
            var result = _context.EmployeeCredentials.SingleOrDefault(p => p.Id == id);
            if (result != null)
            {
                // Handle the case where the user with the specified id doesn't exist
                result.UserName = username;
                result.Password = password;
                result.Status = status;
                result.RequestedCompanyId = requestedCompanyId;
                _context.EmployeeCredentials.Update(result);
                await _context.SaveChangesAsync(_decodedToken);
                return result;
            } 
            else
            {
                throw new NotFoundException($"Employee Credential  id {id} is not found to update");
            }

        }
        public async Task<string> UpdateEmployeePassword(string email, string oldPassword, string newPassword)
        {
            // Find the user by email
            var employeeCredential = await _context.EmployeeCredentials
                .FirstOrDefaultAsync(e => e.Email == email);

            if (employeeCredential == null)
            {
                return "Email not found.";
            }

            // Check if the old password matches
            if (employeeCredential.Password != oldPassword)
            {
                return "Old password is incorrect.";
            }

            // Update the password
            employeeCredential.Password = newPassword;

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
        }
        public async Task<string> GenerateAndSendOtp(string email)
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
                await _emailotpService.SendOtpEmailAsync(otpEmail);

                return "OTP sent to the provided email address.";
            }
            else
            {
                throw new DatabaseOperationException("Failed to update company request data.");
            }
        }
        public async Task SendOtpEmailAsync(string email, string otp)
        {
            var otpEmail = new OtpEmail
            {
                EmailAddress = email,
                Otp = otp
            };
            await _emailotpService.SendOtpEmailAsync(otpEmail);
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
                 .FirstOrDefaultAsync(e => e.Email == email);//&& e.RequestedCompanyId == existingCompanyForm.Id

             if (employeeCredential == null)
             {
                 return "User not found.";
             }

             employeeCredential.Password = newPassword;
                        employeeCredential.DefaultPassword = false;
                       _context.EmployeeCredentials.Update(employeeCredential);


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
        public async Task<string> UpdatePassword(string email, string otp, string newPassword, string confirmPassword)
        {
            // Check if the email and OTP match and are valid
            var existingCompanyForm = await _context.EmployeeCredentials
                .FirstOrDefaultAsync(c => c.Email == email && c.GenerateOtp == otp);

            if (existingCompanyForm == null || existingCompanyForm.OtpExpiration < DateTime.UtcNow)
            {
                return "Invalid or expired OTP.";
            }

            // Validate that newPassword and confirmPassword match
            if (newPassword != confirmPassword)
            {
                return "Passwords do not match.";
            }

            // Update the password in EmployeeCredentials
            var employeeCredential = await _context.EmployeeCredentials
                .FirstOrDefaultAsync(e => e.Email == email);

            if (employeeCredential == null)
            {
                return "User not found.";
            }

            // Hash the new password before storing it
            employeeCredential.Password = newPassword;
            employeeCredential.DefaultPassword = false;

            _context.EmployeeCredentials.Update(employeeCredential);
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
        }


        public bool SoftDelete(int id, short isActive)
        {
            var res = (from row in _context.EmployeeCredentials
                       where row.Id == id
                       select row).FirstOrDefault();
            if (res != null)
            {
                res.IsActive = isActive;
                _context.EmployeeCredentials.Update(res);
                _context.SaveChanges();
                return true;

            }
            return false;
        }
        // Method to hash the password
        /*private string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return $"{Convert.ToBase64String(salt)}:{hashed}";
        }*/

    }
}
