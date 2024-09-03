namespace HRMS_Application.DTO
{
    public class LeaveSummaryDTO
    {
        public int TotalAllocatedLeaves { get; set; }
        public int ApprovedLeaves { get; set; }
        public int PendingLeaves { get; set; }
        public int RejectedLeaves { get; set; }
        public int RemainingLeaves { get; set; }
        public string? LeaveType { get; internal set; }
        public int ApprovedCount { get; internal set; }
        public int PendingCount { get; internal set; }
        public int RejectedCount { get; internal set; }
        public List<LeaveSummaryDTO> LeaveSummaries { get; set; }

    }
}
