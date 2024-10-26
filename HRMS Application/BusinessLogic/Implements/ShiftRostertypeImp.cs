using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class ShiftRostertypeImp : IShiftRostertype
    {
        private readonly HRMSContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtUtils _jwtUtils;
        private List<string>? dToken;
        private int? _decodedToken;
        public ShiftRostertypeImp(HRMSContext context, IHttpContextAccessor httpContextAccessor, IJwtUtils jwtUtils)
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
                        // Handle the case where the user is not found in the database
                        dToken = null;
                    }
                }
            }
        }
        public async Task<bool> deleteShiftRosterType(int id)
        {
            DecodeToken();
            var result = (from row in _context.ShiftRosterTypes
                          where row.Id == id
                          select row).SingleOrDefault();
            _context.ShiftRosterTypes.Remove(result);
            await _context.SaveChangesAsync(_decodedToken);
            return true;
        }

        public List<ShiftRosterType> GetAllShiftRosterType(int CompanyId)
        {
            var result = (from row in _context.ShiftRosterTypes
                          where row.CompanyRequestedId == CompanyId
                          select row).ToList();
            return result;
        }

        public ShiftRosterType GetShiftRosterTypeId(int id)
        {
            var result = (from row in _context.ShiftRosterTypes
                          where row.Id == id 
                          select row).FirstOrDefault();

            return result;
        }

        public async Task<string> InsertShiftRosterType(ShiftRosterType shiftRosterType, int companyId)
        {
            shiftRosterType.CompanyRequestedId = companyId;

            await _context.ShiftRosterTypes.AddAsync(shiftRosterType);

            var result = await _context.SaveChangesAsync();

            return result != 0 ? "New ShiftRosterType inserted successfully" : "Failed to insert new data";
        }
 
        public async Task<ShiftRosterType> updateShiftRosterType(int id, string? Type, string? TimeRange)
        {
            DecodeToken();
            var result = _context.ShiftRosterTypes.SingleOrDefault(p => p.Id == id);
            if (result == null)
            {
                // Handle the case where the user with the specified id doesn't exist
                return null;
            }
            result.Type = Type;
            result.TimeRange = TimeRange;
            _context.ShiftRosterTypes.Update(result);
            await _context.SaveChangesAsync(_decodedToken);
            return result;
        }

    }
}
