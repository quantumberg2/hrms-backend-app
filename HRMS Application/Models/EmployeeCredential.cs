﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HRMS_Application.Models
{
    public partial class EmployeeCredential
    {
        public EmployeeCredential()
        {
            AccountDetails = new HashSet<AccountDetail>();
            AddressInfos = new HashSet<AddressInfo>();
            Attendances = new HashSet<Attendance>();
            DeviceTables = new HashSet<DeviceTable>();
            EmpPersonalInfos = new HashSet<EmpPersonalInfo>();
            EmpSalaries = new HashSet<EmpSalary>();
            EmployeeDetails = new HashSet<EmployeeDetail>();
            EmployeeLeaveAllocations = new HashSet<EmployeeLeaveAllocation>();
            LeaveTrackings = new HashSet<LeaveTracking>();
            UserRolesJs = new HashSet<UserRolesJ>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public short? Status { get; set; }
        public int? RequestedCompanyId { get; set; }
        public string Email { get; set; }
        public bool? DefaultPassword { get; set; }
        public string? GenerateOtp { get; set; }
        public DateTime? OtpExpiration { get; set; }
        public short? IsActive { get; set; }
        public string EmployeeLoginName { get; set; }
        public DateTime? ResignedDate { get; set; }

        public virtual RequestedCompanyForm RequestedCompany { get; set; }
        public virtual ICollection<AccountDetail> AccountDetails { get; set; }
        public virtual ICollection<AddressInfo> AddressInfos { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<DeviceTable> DeviceTables { get; set; }
        public virtual ICollection<EmpPersonalInfo> EmpPersonalInfos { get; set; }
        public virtual ICollection<EmpSalary> EmpSalaries { get; set; }
        public virtual ICollection<EmployeeDetail> EmployeeDetails { get; set; }
        public virtual ICollection<EmployeeLeaveAllocation> EmployeeLeaveAllocations { get; set; }
        public virtual ICollection<LeaveTracking> LeaveTrackings { get; set; }
        public virtual ICollection<UserRolesJ> UserRolesJs { get; set; }
    }
}