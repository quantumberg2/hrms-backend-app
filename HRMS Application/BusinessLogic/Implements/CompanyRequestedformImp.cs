using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.BusinessLogics.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Middleware.Exceptions;
using HRMS_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class CompanyRequestedformImp : ICompanyRequestedform
    {
        private readonly HRMSContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IJwtUtils _jwtUtils;
        private List<string>? dToken;
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
            var result = (from row in _context.RequestedCompanyForms
                          where row.Id == id
                          select row).SingleOrDefault();
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

        /*  public async Task<string> InsertRequestedCompanyForm(RequestedCompanyForm requestedCompanyForm)
          {
              // Set default values
              requestedCompanyForm.InsertedDate = DateTime.UtcNow;
              requestedCompanyForm.UpdatedDate = DateTime.UtcNow;
              requestedCompanyForm.Status = "Requested";

              // Decode the token
              DecodeToken();

              // Add the entity to the context
              _context.RequestedCompanyForms.Add(requestedCompanyForm);

              // Save the changes to the database
              var result = await _context.SaveChangesAsync(_decodedToken);
              if (result != 0)
              {
                  return "New company request inserted successfully";
              }
              else
              {
                  throw new DatabaseOperationException("Failed to insert company request data");
              }
          }*/
        public async Task<string> InsertRequestedCompanyForm(RequestedCompanyForm requestedCompanyForm)
        {
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
                var otpEmail = new OtpEmail
                {
                    EmailAddress = requestedCompanyForm.Email,
                    Otp = generatedOtp // Use the newly generated OTP
                };
                await _emailService.SendOtpEmailAsync(otpEmail);

                return "OTP sent to the provided email address.";
            }
            else
            {
                throw new DatabaseOperationException("Failed to insert company request data");
            }
        }

        private string GenerateOtp()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString(); // Generate a 6-digit OTP
        }


    }
}
