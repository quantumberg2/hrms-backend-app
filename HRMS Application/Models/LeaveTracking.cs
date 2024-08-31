﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HRMS_Application.Models
{
    public partial class LeaveTracking
    {
        public int Id { get; set; }
        public int? EmpCredentialId { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public DateTime? Applied { get; set; }
        public string Status { get; set; }
        public string Files { get; set; }
        public int? LeaveTypeId { get; set; }
        public string Session { get; set; }
        public string Contact { get; set; }
        public string ReasonForLeave { get; set; }

        public virtual EmployeeCredential EmpCredential { get; set; }
        public virtual LeaveType LeaveType { get; set; }
    }
}