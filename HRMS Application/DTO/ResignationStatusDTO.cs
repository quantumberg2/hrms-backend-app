﻿namespace HRMS_Application.DTO
{
    public class ResignationStatusDTO
    {
        public string Reason { get; set; }
        public DateTime? ExitDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Status { get; set; }
        public string managerName { get; set; }

    }
}