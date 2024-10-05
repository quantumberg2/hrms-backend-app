using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Helpers;
using MailKit.Security;
using Microsoft.VisualBasic;
using MimeKit;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class ContactUsImp : IContactUs
    {

        public async Task SendMessageAsync(ContactUsDTO contact)
        {
            string fromEmail = "wequantumberg@gmail.com";
            string password = "kwoipnisqnwmmbyh";

            /*  string FilePath = Directory.GetCurrentDirectory() + "\\SendMessageTemplate.html";*/

            string emailTemplate = constants.ContactTemplate;

            emailTemplate = emailTemplate.Replace("{{Name}}", contact.Name)
                                         .Replace("{{Email}}", contact.Email)
                                         .Replace("{{Phone}}", contact.PhoneNumber)
                                         .Replace("{{Message}}", contact.Message);

            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("HRMS website", fromEmail));
            email.To.Add(MailboxAddress.Parse("srilakshmingr@gmail.com")); //admin@quantumberg.com
            email.Bcc.Add(MailboxAddress.Parse("nitishmashal0@gmail.com"));
            email.Subject = "Email from Quantumberg Contact-us page";

            var builder = new BodyBuilder();
            builder.HtmlBody = emailTemplate;
            email.Body = builder.ToMessageBody();
            using var smtp = new MailKit.Net.Smtp.SmtpClient();

            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(fromEmail, password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);

        }
    }
 }
