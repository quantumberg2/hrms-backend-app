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
                        dToken = userDetails.UserRolesJs.Select(ur => ur.Roles.Name).ToList();
                    }
                    else
                    {
                       
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

        /* public string InsertRequestedCompanyForm(RequestedCompanyForm requestedcompanyform)
         {
             if (!IsValidPhoneNumber(requestedcompanyform.PhoneNumber))
             {
                 return "Invalid phone number. The phone number must be exactly 10 digits.";
             }

             if (!IsValidEmail(requestedcompanyform.Email))
             {
                 return "Invalid email format. Please provide a valid email address.";
             }

             requestedcompanyform.InsertedDate = DateTime.UtcNow;
             requestedcompanyform.UpdatedDate = DateTime.UtcNow;
             requestedcompanyform.Status = "Requested";
             requestedcompanyform.IsActive = 1;

             DecodeToken();

             using (var transaction = _context.Database.BeginTransaction())
             {
                 try
                 {
                     var existingRequestedCompanyForm = _context.RequestedCompanyForms
                         .FirstOrDefault(c => c.Email == requestedcompanyform.Email);

                     var existingEmployeeCredential = _context.EmployeeCredentials
                         .FirstOrDefault(e => e.Email == requestedcompanyform.Email);

                     var existingEmployeedetail = _context.EmployeeDetails
                         .FirstOrDefault(e => e.Email == requestedcompanyform.Email);

                     if (existingRequestedCompanyForm != null && existingRequestedCompanyForm.Status == "Verified"
                         && existingEmployeeCredential != null && existingEmployeedetail != null)
                     {
                         throw new EmailAlreadyExistsException(
                             $"This email {requestedcompanyform.Email} is already registered with us"
                         );
                     }

                     string generatedOtp = GenerateOtp();

                     var existingCompanyForm = _context.RequestedCompanyForms
                         .FirstOrDefault(c => c.Name == requestedcompanyform.Name);

                     if (existingCompanyForm != null)
                     {
                         existingCompanyForm.UpdatedDate = DateTime.UtcNow;
                         _context.RequestedCompanyForms.Update(existingCompanyForm);
                     }
                     else
                     {
                         _context.RequestedCompanyForms.Add(requestedcompanyform);
                         _context.SaveChanges();
                         existingCompanyForm = requestedcompanyform;
                     }

                     if (existingEmployeeCredential != null)
                     {
                         existingEmployeeCredential.GenerateOtp = generatedOtp;
                         existingEmployeeCredential.OtpExpiration = DateTime.UtcNow.AddMinutes(10);
                         existingEmployeeCredential.DefaultPassword = true;
                         existingEmployeeCredential.Password = GeneratePassword();
                         existingEmployeeCredential.RequestedCompanyId = existingCompanyForm.Id;

                         _context.EmployeeCredentials.Update(existingEmployeeCredential);
                     }
                     else
                     {
                         var newEmployeeCredential = new EmployeeCredential
                         {
                             UserName = requestedcompanyform.Email,
                             Password = GeneratePassword(),
                             Email = requestedcompanyform.Email,
                             DefaultPassword = true,
                             GenerateOtp = generatedOtp,
                             OtpExpiration = DateTime.UtcNow.AddMinutes(10),
                             RequestedCompanyId = existingCompanyForm.Id,
                             IsActive = 1,
                         };

                         _context.EmployeeCredentials.Add(newEmployeeCredential);
                         _context.SaveChanges();
                         existingEmployeeCredential = newEmployeeCredential;  // Assign to avoid null reference in EmployeeDetail
                     }

                     if (existingEmployeedetail != null)
                     {
                         existingEmployeedetail.Email = requestedcompanyform.Email;
                         existingEmployeedetail.EmployeeCredentialId = existingEmployeeCredential.Id;
                         existingEmployeedetail.RequestCompanyId = existingCompanyForm.Id;
                     }
                     else
                     {
                         var newEmployeeDetail = new EmployeeDetail
                         {
                             Email = requestedcompanyform.Email,
                             EmployeeCredentialId = existingEmployeeCredential.Id,
                             RequestCompanyId = existingCompanyForm.Id,
                             IsActive = 1,
                         };
                         _context.EmployeeDetails.Add(newEmployeeDetail);
                     }

                     var result = _context.SaveChanges();
                     if (result != 0)
                     {
                         // Sending the OTP email synchronously
                         SendOtpEmail(requestedcompanyform.Email, generatedOtp);
                         transaction.Commit();
                         return "OTP sent to the provided email address.";
                     }
                     else
                     {
                         throw new DatabaseOperationException("Failed to insert company request data");
                     }
                 }
                 catch (Exception)
                 {
                     transaction.Rollback();
                     throw;
                 }
             }
         }
 */

        public async Task<string> InsertRequestedCompanyForm(RequestedCompanyForm requestedcompanyform)
        {
            try
            {
                // Validate phone number and email
                if (!IsValidPhoneNumber(requestedcompanyform.PhoneNumber))
                {
                    return "Invalid phone number. The phone number must be exactly 10 digits.";
                }

                if (!IsValidEmail(requestedcompanyform.Email))
                {
                    return "Invalid email format. Please provide a valid email address.";
                }

                // Set initial fields for the requested company form
                requestedcompanyform.InsertedDate = DateTime.UtcNow;
                requestedcompanyform.UpdatedDate = DateTime.UtcNow;
                requestedcompanyform.Status = "Requested";

                DecodeToken(); // Assuming this sets some token-related state

                // 1. Handle RequestedCompanyForm
                var existingCompanyForm = await _context.RequestedCompanyForms
                    .FirstOrDefaultAsync(c => c.Email == requestedcompanyform.Email);

                if (existingCompanyForm != null)
                {
                    if (existingCompanyForm.Status == "Verified")
                    {
                        throw new EmailAlreadyExistsException(
                            $"This email {requestedcompanyform.Email} is already registered and verified."
                        );
                    }
                    // Update existing company form
                    existingCompanyForm.UpdatedDate = DateTime.UtcNow;
                    _context.RequestedCompanyForms.Update(existingCompanyForm);
                }
                else
                {
                    // Insert new company form
                    await _context.RequestedCompanyForms.AddAsync(requestedcompanyform);
                    await _context.SaveChangesAsync(); // Save to generate the ID
                    existingCompanyForm = requestedcompanyform; // Get the newly created record with ID
                }

                // 2. Handle EmployeeCredential
                var existingEmployeeCredential = await _context.EmployeeCredentials
                    .FirstOrDefaultAsync(e => e.Email == requestedcompanyform.Email);

                string generatedOtp = GenerateOtp(); // Generate OTP for credential

                if (existingEmployeeCredential != null)
                {
                    // Update existing credentials
                    existingEmployeeCredential.GenerateOtp = generatedOtp;
                    existingEmployeeCredential.OtpExpiration = DateTime.UtcNow.AddMinutes(10);
                    existingEmployeeCredential.DefaultPassword = true;
                    existingEmployeeCredential.Password = GeneratePassword();
                    existingEmployeeCredential.RequestedCompanyId = existingCompanyForm.Id; // Reference company form

                    _context.EmployeeCredentials.Update(existingEmployeeCredential);
                }
                else
                {
                    // Create new credentials
                    var newEmployeeCredential = new EmployeeCredential
                    {
                        UserName = requestedcompanyform.Email,
                        Password = GeneratePassword(),
                        Email = requestedcompanyform.Email,
                        DefaultPassword = true,
                        GenerateOtp = generatedOtp,
                        OtpExpiration = DateTime.UtcNow.AddMinutes(10),
                        RequestedCompanyId = existingCompanyForm.Id, // Reference company form
                        IsActive = 1
                    };

                    await _context.EmployeeCredentials.AddAsync(newEmployeeCredential);
                    await _context.SaveChangesAsync(); // Save to generate the ID

                    existingEmployeeCredential = newEmployeeCredential; // Ensure we have the ID
                }

                // 3. Handle EmployeeDetail
                var existingEmployeeDetail = await _context.EmployeeDetails
                    .FirstOrDefaultAsync(e => e.Email == requestedcompanyform.Email);

                // Ensure EmployeeCredentialId and RequestedCompanyId are not null/zero
                if (existingEmployeeCredential.Id == 0 || existingCompanyForm.Id == 0)
                {
                    throw new Exception("Failed to retrieve required data for EmployeeDetail.");
                }

                if (existingEmployeeDetail != null)
                {
                    // Update the employee detail
                    existingEmployeeDetail.Email = requestedcompanyform.Email;
                    existingEmployeeDetail.EmployeeCredentialId = existingEmployeeCredential.Id;
                    existingEmployeeDetail.RequestCompanyId = existingCompanyForm.Id;

                    _context.EmployeeDetails.Update(existingEmployeeDetail);
                }
                else
                {
                    // Insert new employee detail
                    var newEmployeeDetail = new EmployeeDetail
                    {
                        Email = requestedcompanyform.Email,
                        EmployeeCredentialId = existingEmployeeCredential.Id,
                        RequestCompanyId = existingCompanyForm.Id,
                        EmployeeNumber = null,  

                        IsActive = 1
                    };

                    await _context.EmployeeDetails.AddAsync(newEmployeeDetail);
                }

                // Save all changes
                var result = await _context.SaveChangesAsync();

                if (result != 0)
                {
                    await SendOtpEmailAsync(requestedcompanyform.Email, generatedOtp);
                    return "OTP sent to the provided email address.";
                }
                else
                {
                    throw new DatabaseOperationException("Failed to insert company request data");
                }
            }
            catch (DbUpdateException dbEx)
            {
                // Handle database errors
                var innerException = dbEx.InnerException?.Message ?? dbEx.Message;
                throw new DatabaseOperationException($"Failed to insert data: {innerException}");
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred: " + ex.Message);
            }
        }




        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
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
