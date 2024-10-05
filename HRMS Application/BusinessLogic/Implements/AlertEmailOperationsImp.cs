using HRMS_Application.BusinessLogic.Interface;
using System.Net.Mail;
using System.Net;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class AlertEmailOperationsImp : IAlertEmailOperations
    {
        private readonly SmtpClient _smtpClient;

        public AlertEmailOperationsImp()
        {
            _smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Credentials = new NetworkCredential("wequantumberg@gmail.com", "kwoipnisqnwmmbyh"),
                Port = 587,
                EnableSsl = true
            };
        }
        public void SendEmail(string emailTemplate, Dictionary<string, string> parameters)
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
                _smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }
    }
}
