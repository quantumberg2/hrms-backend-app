namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IUpdatePassword
    {
        public  Task<string> UpdatePassword(string email, string otp, string newPassword);
    }
}
