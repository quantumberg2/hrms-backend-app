namespace HRMS_Application.DTO
{
    public class NewsDTO
    {
        public DateTime? DisplayDate { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string Heading { get; set; }
        public string Desciption { get; set; }
        public IFormFile? ImgUrl { get; set; }
        public short? IsActive { get; set; }
    }
}
