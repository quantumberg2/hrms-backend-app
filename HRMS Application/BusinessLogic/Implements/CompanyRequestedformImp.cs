using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.BusinessLogics.Interface;
using HRMS_Application.Middleware.Exceptions;
using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class CompanyRequestedformImp : ICompanyRequestedform
    {
        private readonly HRMSContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IJwtUtils _jwtUtils;
        private List<string>? dToken;
        private int? _decodedToken;
        public CompanyRequestedformImp(HRMSContext context, IHttpContextAccessor httpContextAccessor, IJwtUtils jwtUtils)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _jwtUtils = jwtUtils;
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

        public async Task<string> InsertRequestedCompanyForm(RequestedCompanyForm requestedCompanyForm)
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
        }

    }
}
