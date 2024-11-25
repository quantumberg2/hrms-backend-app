namespace HRMS_Application.DTO
{
    public class ResignationStatusDTO
    {
        public int id { get; set; }
        public string Reason { get; set; }
        public DateTime? ExitDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? StartDate { get; set; }
        public string Status { get; set; }
        public string managerName { get; set; }

    }
}
