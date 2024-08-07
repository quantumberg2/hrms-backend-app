using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.Threading.Tasks;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;

public class EmailService : IEmailService
{
    private readonly string _fromEmail = "wequantumberg@gmail.com";
    private readonly string _fromName = "Quantumberg";
    private readonly string _password = "kwoipnisqnwmmbyh";
    private readonly string _smtpServer = "smtp.gmail.com";
    private readonly int _smtpPort = 587;

    public async Task SendOtpEmailAsync(OtpEmail otpEmail)
    {
        var email = new MimeMessage();
        email.From.Add(new MailboxAddress(_fromName, _fromEmail));
        email.To.Add(MailboxAddress.Parse(otpEmail.EmailAddress));
        email.Subject = "Your OTP Code";

        var builder = new BodyBuilder
        {
            HtmlBody = $"Your OTP code is: {otpEmail.Otp}"
        };
        email.Body = builder.ToMessageBody();

        using var smtp = new MailKit.Net.Smtp.SmtpClient();
        smtp.Connect(_smtpServer, _smtpPort, SecureSocketOptions.StartTls);
        smtp.Authenticate(_fromEmail, _password);
        await smtp.SendAsync(email);
        smtp.Disconnect(true);
    }
}
