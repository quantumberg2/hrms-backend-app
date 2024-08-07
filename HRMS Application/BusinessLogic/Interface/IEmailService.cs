using HRMS_Application.DTO;

namespace HRMS_Application.BusinessLogic.Interface
{
    public interface IEmailService
    {
       public Task SendOtpEmailAsync(OtpEmail otpEmail);
    }
}
