namespace HRMS_Application.DTOs
{
    public class UserDto
    {
       // public string Name { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
       // public string Password { get; set; }
        public List<string> Roles { get; set; }
    }
}
