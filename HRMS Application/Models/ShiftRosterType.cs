﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HRMS_Application.Models
{
    public partial class ShiftRosterType
    {
        public ShiftRosterType()
        {
            ShiftRosters = new HashSet<ShiftRoster>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string TimeRange { get; set; }
        public int? CompanyRequestedId { get; set; }

        public virtual ICollection<ShiftRoster> ShiftRosters { get; set; }
    }
}