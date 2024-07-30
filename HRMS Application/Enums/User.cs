using HRMS_Application.Enums;
using System.Text.Json.Serialization;

namespace HRMS_Application.Entities
{
    public class User
    {
        public User()
        {
            //    UserRoles = new List<string>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }

        //  public List<string> UserRoles  { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }
    }
}
