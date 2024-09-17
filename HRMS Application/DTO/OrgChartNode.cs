﻿namespace HRMS_Application.DTO
{
    public class OrgChartNode
    {
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public string? Designation {  get; set; }
        public List<EmployeeDetailDto> Employees { get; set; }
    }
    public class EmployeeDetailDto
    {
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string? Designation { get; set; }
      
    }
}
