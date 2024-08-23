using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using MailKit.Security;
using MimeKit;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class EmailPasswordImp : IEmailPassword
    {
        private readonly string _fromEmail = "wequantumberg@gmail.com";
        private readonly string _fromName = "Quantumberg";
        private readonly string _password = "kwoipnisqnwmmbyh";
        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly int _smtpPort = 587;

        public async Task SendOtpEmailAsync(Generatepassword generatepassword)
        {
            if (!IsValidEmail(generatepassword.EmailAddress))
            {
                throw new ArgumentException("Invalid email address.");
            }

            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_fromName, _fromEmail));
            email.To.Add(MailboxAddress.Parse(generatepassword.EmailAddress));
            email.Subject = "Your UserName and Password";

            var builder = new BodyBuilder
            {
                HtmlBody = $"Your Password code is: {generatepassword.Password}<br/>Your Username is: {generatepassword.UserName}"
            };
            email.Body = builder.ToMessageBody();

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect(_smtpServer, _smtpPort, SecureSocketOptions.StartTls);
            smtp.Authenticate(_fromEmail, _password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                // Use MailboxAddress.Parse to validate the email address
                var address = MailboxAddress.Parse(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
