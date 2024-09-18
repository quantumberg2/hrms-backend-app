﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HRMS_Application.Models
{
    public partial class EmpPersonalInfo
    {
        public int Id { get; set; }
        public int? EmployeeCredentialId { get; set; }
        public DateTime? Dob { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public string EmpStatus { get; set; }
        public string EmailId { get; set; }
        public string PersonalEmail { get; set; }
        public string MaritalStatus { get; set; }
        public string BloodGroup { get; set; }
        public string SpouseName { get; set; }
        public bool? PhysicallyChallenged { get; set; }
        public string EmergencyContact { get; set; }
        public short? IsActive { get; set; }
        public string Gender { get; set; }

        public virtual EmployeeCredential EmployeeCredential { get; set; }
    }
}