﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HRMS_Application.Models
{
    public partial class UserRolesJ
    {
        public int Id { get; set; }
        public int? EmployeeCredentialId { get; set; }
        public int? RolesId { get; set; }

        public virtual EmployeeCredential EmployeeCredential { get; set; }
        public virtual Role Roles { get; set; }
    }
}