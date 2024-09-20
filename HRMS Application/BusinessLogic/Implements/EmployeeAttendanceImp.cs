
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
            var currentYear = DateTime.Now.Year;
            var startDate = new DateTime(currentYear, 1, 1, 0, 0, 0, DateTimeKind.Local);
            var endDate = new DateTime(currentYear, 12, 31, 23, 59, 59, DateTimeKind.Local);


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

            var attendanceInfo = (from date in Enumerable.Range(0, (endDate - startDate).Days + 1)
                                  let currentDate = startDate.AddDays(date)
                                  let isSunday = currentDate.DayOfWeek == DayOfWeek.Sunday

                                  join device in _hrmsContext.DeviceTables
                                      on new { EmpCredentialId = empCredId, Date = currentDate.Date }
                                      equals new { EmpCredentialId = device.EmpCredentialId ?? 0, Date = device.InsertedDate.Value.Date } into deviceJoin
                                  from device in deviceJoin.DefaultIfEmpty()

                                  join leave in _hrmsContext.LeaveTrackings
                                      on new { EmpCredentialId = empCredId, Date = currentDate.Date }
                                      equals new { EmpCredentialId = leave.EmpCredentialId ?? 0, Date = leave.Startdate.Value.Date } into leaveJoin
                                  from leave in leaveJoin.DefaultIfEmpty()

                                  join holiday in _hrmsContext.Holidays
                                      on currentDate.Date equals holiday.Date.Value.Date into holidayJoin
                                  from holiday in holidayJoin.DefaultIfEmpty()

                                  let shift = shiftInfo.Find(s =>
                                      currentDate.Date >= s.StartDate.Value.Date &&
                                      currentDate.Date <= s.EndDate.Value.Date)

                                  select new AttendanceDTO
                                  {
                                      Date = currentDate,
                                      TimeIn = device != null ? device.TimeIn : null,
                                      TimeOut = device != null ? device.TimeOut : null,
                                      Status = isSunday ? "Holiday" :
                                               holiday != null ? "Holiday" :
                                               leave != null ? "Leave" :
                                               device != null ? "Present" :
                                               (currentDate > DateTime.Now ? " " : "Absent"),
                                      Shift = shift != null ? shift.ShiftType : null 
                                  }).ToList();

            return attendanceInfo;
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
                // Handle the case where the user with the specified id doesn't exist
                return null;
            }
            
            result.EmpCredentialId = empcredentialId;
            _hrmsContext.Attendances.Update(result);
          
            result.EmpCredentialId= empcredentialId;
            _hrmsContext.Attendances.Update(result);
            await _hrmsContext.SaveChangesAsync(_decodedToken);
            return result;
        }
    }
}
