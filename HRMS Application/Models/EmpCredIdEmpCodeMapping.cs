﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HRMS_Application.Models
{
    public partial class EmpCredIdEmpCodeMapping
    {
        public int Id { get; set; }
        public int? EmpCredId { get; set; }
        public int? EmpCode { get; set; }

        public virtual EmployeeCredential EmpCred { get; set; }
    }
}