using Microsoft.AspNetCore.Components.Web;

namespace HRMS_Application.DTO
{
    public class LeaveApprovalDTO
    {
        public int Id { get; set; }
        public string EmployeeNumber { get; set; }
        public string Name { get; set; }
        public string LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NoofDays { get; set; }
    }
}
