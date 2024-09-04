﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HRMS_Application.Models
{
    public partial class LeaveType
    {
        public LeaveType()
        {
            EmployeeLeaveAllocations = new HashSet<EmployeeLeaveAllocation>();
            LeaveTrackings = new HashSet<LeaveTracking>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public int? Days { get; set; }
        public int? CompanyId { get; set; }
        public int? Year { get; set; }
        public short? IsActive { get; set; }

        public virtual RequestedCompanyForm Company { get; set; }
        public virtual ICollection<EmployeeLeaveAllocation> EmployeeLeaveAllocations { get; set; }
        public virtual ICollection<LeaveTracking> LeaveTrackings { get; set; }
    }
}