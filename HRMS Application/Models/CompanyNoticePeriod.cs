﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HRMS_Application.Models
{
    public partial class CompanyNoticePeriod
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int? Days { get; set; }

        public virtual RequestedCompanyForm Company { get; set; }
    }
}