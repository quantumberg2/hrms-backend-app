namespace HRMS_Application.DTO
{
    public class OrgChartNode
    {
        public string? FullName { get; set; }
        public string? PositionName { get; set; }
        public string? Email { get; set; }
        public string? ImageURl { get; set; }
        public List<OrgChartNode> Subordinates { get; set; } = new List<OrgChartNode>();
    }
}
