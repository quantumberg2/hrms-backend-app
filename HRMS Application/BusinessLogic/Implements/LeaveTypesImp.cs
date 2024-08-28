using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class LeaveTypesImp : ILeaveTypes
    {
        private HRMSContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtUtils _jwtUtils;
        public List<string>? dToken;
        private int? _decodedToken;
        public LeaveTypesImp(HRMSContext context, IHttpContextAccessor httpContextAccessor, IJwtUtils jwtUtils)
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

        public bool deleteLeaveType(int id)
        {
            DecodeToken();
            var result = (from row in _context.LeaveTypes
                          where row.Id == id
                          select row).SingleOrDefault();
            _context.LeaveTypes.Remove(result);
            _context.SaveChanges();
            return true;
        }

        public List<LeaveType> GetAllLeaveType()
        {
            var result = (from row in _context.LeaveTypes
                          select row).ToList();
            return result;
        }

        public LeaveType GetLeaveTypeById(int id)
        {
            var result = (from row in _context.LeaveTypes
                          where row.Id == id
                          select row).FirstOrDefault();
            return result;
        }

        public LeaveType GetLeaveTypeByType(string Type)
        {
            var result = (from row in _context.LeaveTypes
                          where row.Type == Type
                          select row).FirstOrDefault();
            return result;
        }

        public async Task <string> InsertLeaveType(LeaveType leaveType)
        {
            DecodeToken();
           await _context.LeaveTypes.AddAsync(leaveType);
            var result = await _context.SaveChangesAsync(_decodedToken);
            if (result != 0)
            {
                return "new leavetype inserted successfully";

            }
            else
            {
                return "failed to insert new data";
            }
        }

        public LeaveType UpdateLeaveType(int id, string? name, int? requestedcompanyId)
        {
            throw new NotImplementedException();
        }
    }
}
