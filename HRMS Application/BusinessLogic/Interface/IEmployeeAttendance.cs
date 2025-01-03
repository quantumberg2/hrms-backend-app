﻿using HRMS_Application.DTO;
using HRMS_Application.Models;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IEmployeeAttendance
    {   
        public List<Attendance> GetAllEmpAttendence();
        public Attendance  GetById(int id);
        public List<AttendanceDTO> GetAttendanceByCredId(int empCredId);
        public  Task<string> InsertEmployeeAttendence(Attendance employeeAttendence);
        public Task<Attendance> UpdateEmployeeAttendence(int id, DateTime? Timein, DateTime? Timeout, string? Remark, int empcredentialId);
        public Task<Attendance> UpdateAttendanceInfo(Attendance attendance);
        public Task<bool> DeleteEmployeeAttendance(int id);
    }
}
