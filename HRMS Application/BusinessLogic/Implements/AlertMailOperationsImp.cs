using HRMS_Application.BusinessLogic.Interface;
using System.Net.Mail;
using System.Net;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class AlertMailOperationsImp : IAlertEmailOperations
    {
        private readonly SmtpClient _smtpClient;
        public AlertMailOperationsImp()
        {
            _smtpClient = new SmtpClient("smtp.gmail.com")
            {
                // Your Gmail email and password (used to authenticate with the SMTP server)
                Credentials = new NetworkCredential("wequantumberg@gmail.com", "kwoipnisqnwmmbyh"),
                Port = 587, // The SMTP port for Gmail's service
                EnableSsl = true // Enabling SSL to securely send the email
            };
        }

        public async Task SendEmailAsync(string emailTemplate, Dictionary<string, string> parameters)
        {
            string subject = parameters.ContainsKey("Subject") ? parameters["Subject"] : "Notification";

            string body = emailTemplate;
            foreach (var param in parameters)
            {
                body = body.Replace($"{{{{{param.Key}}}}}", param.Value);
            }

            var mailMessage = new MailMessage
            {
                From = new MailAddress("wequantumberg@gmail.com", "HRMS website"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(parameters["To"]);

            try
            {
                // Send email asynchronously
                await _smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }
    }
}
