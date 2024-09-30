using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using MailKit.Security;
using MimeKit;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class ContactUsImp : IContactUs
    {

        public async Task SendMessageAsync(ContactUsDTO contact)
        {
            string fromEmail = "wequantumberg@gmail.com";
            string password = "kwoipnisqnwmmbyh";

            string FilePath = Directory.GetCurrentDirectory() + "\\SendMessageTemplate.html";
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();

            MailText = MailText.Replace("[Name]", contact.Name).Replace("[Email]", contact.Email).Replace("[Phone]", contact.PhoneNumber).Replace("[Message]", contact.Message);
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("HRMS website", fromEmail));
            email.To.Add(MailboxAddress.Parse("srilakshmingr@gmail.com")); //admin@quantumberg.com
/*            email.Bcc.Add(MailboxAddress.Parse("srilakshmingr@gmail.com"));*/
            email.Subject = "Email from Quantumberg Contact-us page";

            var builder = new BodyBuilder();
            builder.HtmlBody = MailText;
            email.Body = builder.ToMessageBody();
            using var smtp = new MailKit.Net.Smtp.SmtpClient();

            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(fromEmail, password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);

        }
    }
 }
