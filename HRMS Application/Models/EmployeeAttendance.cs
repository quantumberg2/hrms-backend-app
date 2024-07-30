﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HRMS_Application.Models
{
    public partial class EmployeeAttendance
    {
        public int Id { get; set; }
        public int? EmployeeCredentialId { get; set; }
        public int? LeaveId { get; set; }
        public int? HolidayId { get; set; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public string Remarks { get; set; }

        public virtual EmployeeCredential EmployeeCredential { get; set; }
        public virtual Holiday Holiday { get; set; }
        public virtual LeaveType Leave { get; set; }
    }
}