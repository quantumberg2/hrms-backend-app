namespace HRMS_Application.DTO
{
    public class OrgChartNode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ManagerId { get; set; } // Assuming ManagerId can be null
        public string Email { get; set; }
        public int? PositionId { get; set; }
        public List<OrgChartNode> Children { get; set; } = new List<OrgChartNode>();
        public int? EmployeeCredentialId { get; internal set; }
    }
}
