﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HRMS_Application.Models
{
    public partial class File
    {
        public int Id { get; set; }
        public string FileUrl { get; set; }
        public int? ObjectId { get; set; }
        public string ObjectName { get; set; }
        public bool? IsActive { get; set; }
        public string Tags { get; set; }
    }
}