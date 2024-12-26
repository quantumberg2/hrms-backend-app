using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class OrganizationWorkingDaysImp : IOrganizationWorkingDays
    {
        private readonly HRMSContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtUtils _jwtUtils;
        private List<string>? dToken;
        private int? _decodedToken;
        public OrganizationWorkingDaysImp(HRMSContext context, IHttpContextAccessor httpContextAccessor, IJwtUtils jwtUtils)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _httpContextAccessor = httpContextAccessor;

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
                        dToken = null;
                    }
                }
            }
        }
        public async Task<bool> deleteOrganizationWorkingDay(int id)
        {
            DecodeToken();
            var result = (from row in _context.CompanyNoticePeriods
                          where row.Id == id
                          select row).SingleOrDefault();
            _context.CompanyNoticePeriods.Remove(result);
            await _context.SaveChangesAsync(_decodedToken);
            return true;
        }

        public List<OrganizationWorkingDay> GetOrganizationWorkingDay(int CompanyId)
        {
            var result = (from row in _context.OrganizationWorkingDays
                          where row.CompanyId == CompanyId
                          select row).ToList();
            return result;
        }

        public OrganizationWorkingDay GetOrganizationWorkingDayId(int id)
        {
            var result = (from row in _context.OrganizationWorkingDays
                          where row.Id == id
                          select row).FirstOrDefault();

            return result;
        }

        public async Task<string> InsertOrganizationWorkingDay(OrganizationWorkingDay organizationWorking, int CompanyId)
        {
            organizationWorking.CompanyId = CompanyId;

            await _context.OrganizationWorkingDays.AddAsync(organizationWorking);

            var result = await _context.SaveChangesAsync();

            return result != 0 ? "New OrganizationWorkingDay inserted successfully" : "Failed to insert new data";
        }
    }
}
