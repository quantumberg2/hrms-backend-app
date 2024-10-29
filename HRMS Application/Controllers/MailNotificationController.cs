using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Enums;
using HRMS_Application.Helpers;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HRMS_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailNotificationController : ControllerBase
    {
        private readonly ILogger<MailNotificationController> _logger;

        public MailNotificationController(ILogger<MailNotificationController> logger)
        {
            _logger = logger;
        }

        [HttpPost("SendCustomEmail")]
        public async Task<IActionResult> SendMail([FromForm] EmailNotification objEmail)
        {
            _logger.LogInformation("Send mail method started");

            try
            {
                string toEmail = string.Empty;
                string fromEmail = "wequantumberg@gmail.com";
                string password = "kwoipnisqnwmmbyh"; 
                string emailTemplate = constants.MailTemplate;
                string subject = string.Empty;

                switch (objEmail.appId)
                {
                    case AppId_s.Quantumberg:
                        toEmail = "srilakshmingr@gmail.com";
                        emailTemplate = emailTemplate.Replace("[Name]", objEmail.Name)
                                                     .Replace("[Email]", objEmail.Email)
                                                     .Replace("[Phone]", objEmail.PhoneNumber)
                                                     .Replace("[Message]",objEmail.Message)
                                                     .Replace("[Application]","Quantumberg")
                                                     .Replace("[imageUrl]", "https://www.quantumberg.com/assets/QUANTUMBERG-LOGO1-af6161d6.png")
                                                     .Replace("[HR_Info]", "Sihi<br/>Quantumberg")
                                                     .Replace("[CompanyAddress]", "Some Firm Ltd, 35 Avenue. City");
                        subject = "Quantumberg Support";
                        break;

                    case AppId_s.HRMS:
                        toEmail = "srilakshmingr@gmail.com";
                        emailTemplate = emailTemplate.Replace("[Name]", objEmail.Name)
                                                     .Replace("[Email]", objEmail.Email)
                                                     .Replace("[Phone]", objEmail.PhoneNumber)
                                                     .Replace("[Message]", objEmail.Message)
                                                     .Replace("[Application]", "HRMS")
                                                     .Replace("[imageUrl]", "https://www.quantumberg.com/assets/QUANTUMBERG-LOGO1-af6161d6.png")
                                                     .Replace("[HR_Info]", "Radha<br/>HRMS")
                                                     .Replace("[CompanyAddress]", "Some Firm Ltd, 35 Avenue. City");
                        subject = "HRMS Support";
                        break;

                    case AppId_s.DeviWebsite:
                        toEmail = "srilakshmingr@gmail.com";
                        emailTemplate = emailTemplate.Replace("[Name]", objEmail.Name)
                                                     .Replace("[Email]", objEmail.Email)
                                                     .Replace("[Phone]", objEmail.PhoneNumber)
                                                     .Replace("[Message]", objEmail.Message)
                                                     .Replace("[Application]", "Devi website")
                                                     .Replace("[imageUrl]", "https://www.quantumberg.com/assets/QUANTUMBERG-LOGO1-af6161d6.png")
                                                     .Replace("[HR_Info]", "Krishna<br/>Devi Templae")
                                                     .Replace("[CompanyAddress]", "Some Firm Ltd, 35 Avenue. City");
                        subject = "Devi Temple Website Support";
                        break;

                    case AppId_s.Triguna:
                        toEmail = "srilakshmingr@gmail.com";
                        emailTemplate = emailTemplate.Replace("[Name]", objEmail.Name)
                                                    .Replace("[Email]", objEmail.Email)
                                                    .Replace("[Phone]", objEmail.PhoneNumber)
                                                    .Replace("[Message]", objEmail.Message)
                                                    .Replace("[Application]", "Triguna")
                                                   .Replace("[imageUrl]", "https://www.quantumberg.com/assets/QUANTUMBERG-LOGO1-af6161d6.png")
                                                    .Replace("[HR_Info]", "Karna<br/>Triguna")
                                                    .Replace("[CompanyAddress]", "Some Firm Ltd, 35 Avenue. City");
                        subject = "Triguna Support";
                        break;

                    default:
                        return BadRequest("Invalid App ID.");
                }

                var email = new MimeMessage();
                email.From.Add(new MailboxAddress("App Support", fromEmail));
                email.To.Add(MailboxAddress.Parse(toEmail)); 
                email.Subject = subject;

                var builder = new BodyBuilder { HtmlBody = emailTemplate };
                email.Body = builder.ToMessageBody();

                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(fromEmail, password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);

                _logger.LogInformation("Email sent successfully");
                return Ok("Email sent successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while sending email");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while sending email.");
            }
        }
    }
}
