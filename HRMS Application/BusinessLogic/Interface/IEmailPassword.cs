using HRMS_Application.DTO;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IEmailPassword
    {
        public Task SendOtpEmailAsync(Generatepassword generatepassword);
    }
}
