
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
            // Fetch attendance data based on EmpCredentialId (without a Date column)
            var res = (from row in _hrmsContext.Attendances
                       where row.EmpCredentialId == empCredId
                       select row).ToList();

            // Fetch the device login info which contains the InsertedDate (the date reference)
            var loginInfo = (from row in _hrmsContext.DeviceTables
                             where row.EmpCredentialId == empCredId
                             select row).ToList();

            List<AttendanceDTO> attendanceList = new List<AttendanceDTO>();

            foreach (var login in loginInfo)
            {
                // For each login entry (which has a date), find the corresponding attendance record
                var attendance = res.FirstOrDefault(a => a.EmpCredentialId == login.EmpCredentialId);

                AttendanceDTO objAttendanceInfo = new AttendanceDTO
                {
                    Date = login.InsertedDate,
                    Status = attendance?.Status ?? "Absent"
                };

                if (attendance != null && attendance.Status == "Present")
                {
                    objAttendanceInfo.TimeIn = login.TimeIn;
                    objAttendanceInfo.TimeOut = login.TimeOut;
                }
                else
                {
                    objAttendanceInfo.TimeIn = null;
                    objAttendanceInfo.TimeOut = null;
                }

                attendanceList.Add(objAttendanceInfo);
            }

            return attendanceList;
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
