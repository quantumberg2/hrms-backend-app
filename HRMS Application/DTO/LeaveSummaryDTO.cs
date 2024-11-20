namespace HRMS_Application.DTO
{
    public class LeaveSummaryDTO
    {
        public int TotalAllocatedLeaves { get; set; }
        public int ApprovedLeaves { get; set; }
        public int PendingLeaves { get; set; }
        public int RejectedLeaves { get; set; }
        public int RemainingLeaves { get; set; }
        public string? LeaveType { get;  set; }
        public int ApprovedCount { get;  set; }
        public int PendingCount { get;  set; }
        public int RejectedCount { get;  set; }
        public List<LeaveSummaryDTO> LeaveSummaries { get; set; }

    }
}
