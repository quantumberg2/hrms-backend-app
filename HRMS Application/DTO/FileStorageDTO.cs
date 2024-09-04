namespace HRMS_Application.DTO
{
    public class FileStorageDTO
    {
        public int? ObjectId { get; set; }
        public string? ObjectName { get; set; }
        public bool? IsActive { get; set; }
        public string? Tags { get; set; }
        public IFormFile? FileContent{ get; set; }
    }
}
