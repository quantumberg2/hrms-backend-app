using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class ShiftRosterImp : IShiftRoster
    {
        private readonly HRMSContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtUtils _jwtUtils;
        private List<string>? dToken;
        private int? _decodedToken;
        public ShiftRosterImp(HRMSContext context, IHttpContextAccessor httpContextAccessor, IJwtUtils jwtUtils)
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
        public async Task<bool> deleteShiftRoster(int id)
        {
            DecodeToken();
            var result = (from row in _context.ShiftRosters
                          where row.Id == id
                          select row).SingleOrDefault();
            _context.ShiftRosters.Remove(result);
            await _context.SaveChangesAsync(_decodedToken);
            return true;
        }

        public List<ShiftRoster> GetAllShiftRoster()
        {
            var result = (from row in _context.ShiftRosters
                          select row).ToList();
            return result;
        }

        public ShiftRoster GetShiftRosterId(int id)
        {
            var result = (from row in _context.ShiftRosters
                          where row.Id == id
                          select row).FirstOrDefault();

            return result;
        }

        public async Task<string> InsertShiftRoster(ShiftRoster shiftRoster)
        {
            DecodeToken();

            // Check if a shift roster entry for the same employee credential already exists
            var existingShiftRoster = await _context.ShiftRosters
                .FirstOrDefaultAsync(sr => sr.EmpCredentialId == shiftRoster.EmpCredentialId);

            if (existingShiftRoster != null)
            {
                // Update the existing ShiftRoster entry
                existingShiftRoster.ShiftRosterTypeId = shiftRoster.ShiftRosterTypeId;
                existingShiftRoster.Startdate = shiftRoster.Startdate;
                existingShiftRoster.Enddate = shiftRoster.Enddate;

                _context.ShiftRosters.Update(existingShiftRoster);
            }
            else
            {
                // Create a new ShiftRoster entry
                await _context.ShiftRosters.AddAsync(shiftRoster);
            }

            // Save changes to the database
            var result = await _context.SaveChangesAsync(_decodedToken);

            if (result != 0)
            {
                return existingShiftRoster != null
                    ? "ShiftRoster updated successfully"
                    : "New ShiftRoster inserted successfully";
            }
            else
            {
                return "Failed to insert or update ShiftRoster";
            }
        }
    }
}
