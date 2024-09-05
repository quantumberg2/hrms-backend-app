using HRMS_Application.Models;
using HRMS_Application.Models.Users;

namespace HRMS_Application.BusinessLogics.Interface
{
    public interface IUser
    {
        //public AuthenticateResponse Authenticate(AuthenticateRequest model);
        public List<EmployeeCredential> GetAllUser();     
        public EmployeeCredential GetById(int id);
        public string InsertUser(EmployeeCredential employeeCredential);
        public string UpdateUsers(int id, EmployeeCredential employeeCredential);
        public bool DeleteUsers(int id);
        public bool SoftDelete(int id, short isActive);

    }
}
