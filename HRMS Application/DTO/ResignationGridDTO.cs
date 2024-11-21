using System.Collections.Generic;

namespace HRMS_Application.DTO
{
    public class ResignationGridDTO
    {
     public string  EmployeeName { get; set; }
     public string EmployeeNumber { get; set; }
     public string Reason { get; set; }
     public string Status { get; set; }
     public DateTime? SeparationDate { get; set; }
     public DateTime? LastWorkingDay { get; set; }
    }
}
