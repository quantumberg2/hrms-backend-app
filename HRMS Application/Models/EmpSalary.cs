﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HRMS_Application.Models
{
    public partial class EmpSalary
    {
        public int Id { get; set; }
        public int? EmployeeCredentialId { get; set; }
        public string SalaryRange { get; set; }
        public decimal? AnnualIncome { get; set; }
        public decimal? Loan { get; set; }
        public decimal? Insurance { get; set; }
        public short? IsActive { get; set; }

        public virtual EmployeeCredential EmployeeCredential { get; set; }
    }
}