
using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.BusinessLogics.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class EmployeeAttendanceImp : IEmployeeAttendance
    {
        private readonly HRMSContext _hrmsContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtUtils _jwtUtils;
        private List<string>? dToken;
        private int? _decodedToken;
        public EmployeeAttendanceImp(HRMSContext hrmscontext, IHttpContextAccessor httpContextAccessor, IJwtUtils jwtUtils)
        {
            _hrmsContext = hrmscontext;
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
                    var userDetails = _hrmsContext.EmployeeCredentials.FirstOrDefault(e => e.Id == userId.Value);
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

        public async Task<bool> DeleteEmployeeAttendance(int id)
        {
            DecodeToken();
            var result = (from row in _hrmsContext.Attendances
                          where row.Id == id
                          select row).SingleOrDefault();
            _hrmsContext.Attendances.Remove(result);
            await _hrmsContext.SaveChangesAsync(_decodedToken);
            return true;
        }

        public List<Attendance> GetAllEmpAttendence()
        {
            var result = (from row in _hrmsContext.Attendances
                          select row).ToList();
            return result;
        }

        public List<AttendanceDTO> GetAttendanceByCredId(int empCredId)
        {
            // Fetch all attendance records for the employee
            var attendanceInfo = (from row in _hrmsContext.Attendances
                                  where row.EmpCredentialId == empCredId
                                  select row).ToList();

            // Fetch shift info, filtering based on attendance date within shift range
            var shiftInfo = (from shift in _hrmsContext.ShiftRosters
                             join shiftType in _hrmsContext.ShiftRosterTypes
                             on shift.ShiftRosterTypeId equals shiftType.Id
                             where shift.EmpCredentialId == empCredId
                             select new
                             {
                                 ShiftId = shift.Id,
                                 ShiftType = shiftType.Type,
                                 StartDate = shift.Startdate,
                                 EndDate = shift.Enddate
                             }).ToList();

            // Combine attendance and shift info based on date matching
            var attendanceDTO = (from attendance in attendanceInfo
                                 let shift = shiftInfo.FirstOrDefault(s => attendance.Date.HasValue && attendance.Date.Value >= s.StartDate && attendance.Date.Value <= s.EndDate)
                                 select new AttendanceDTO
                                 {
                                     TimeIn = attendance.TimeIn,
                                     TimeOut = attendance.Timeout,
                                     Status = attendance.Status,
                                     Date = attendance.Date.HasValue ? attendance.Date.Value : DateTime.MinValue, // Handle null Date
                                     Shift = shift != null ? shift.ShiftType : " "
                                 }).ToList();

            return attendanceDTO;
        }

        public Attendance GetById(int id)
        {
            var res = (from row in _hrmsContext.Attendances
                       where row.Id == id
                       select row).FirstOrDefault();
            return res;
        }

        public async Task<string> InsertEmployeeAttendence(Attendance employeeAttendence)
        {
            DecodeToken();
            await _hrmsContext.Attendances.AddAsync(employeeAttendence);
            var result = await _hrmsContext.SaveChangesAsync(_decodedToken);
            if (result != 0)
            {
                return "new Employee inserted successfully";

            }
            else
            {
                return "failed to insert new data";
            }
        }
        public async Task<Attendance> UpdateEmployeeAttendence(int id, DateTime? Timein, DateTime? Timeout, string? Remark, int empcredentialId)
        {
            var result = _hrmsContext.Attendances.SingleOrDefault(p => p.Id == id);
            if (result == null)
            {
                return null;
            }
            
            result.EmpCredentialId = empcredentialId;
            _hrmsContext.Attendances.Update(result);
          
            result.EmpCredentialId= empcredentialId;
            _hrmsContext.Attendances.Update(result);
            await _hrmsContext.SaveChangesAsync(_decodedToken);
            return result;
        }

        public Task<Attendance> UpdateAttendanceInfo(Attendance attendance)
        {
            throw new NotImplementedException();
        }
    }
}
