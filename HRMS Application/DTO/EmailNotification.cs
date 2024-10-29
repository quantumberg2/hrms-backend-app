using HRMS_Application.Enums;

namespace HRMS_Application.DTO
{
    public class EmailNotification
    {
        public AppId_s appId {  get; set; } 
      //  public string QueryTopic { get; set; }
        public string Email { get; set; }
      //  public string Comments { get; set; }

       public string Name { get; set; }
       public string PhoneNumber { get; set; }
       public string Message { get; set; }
    }
}
