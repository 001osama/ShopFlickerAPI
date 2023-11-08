using MailKit.Net.Smtp;
using MimeKit;
using ShopFlickerAPI.Models.DTO;
using ShopFlickerAPI.Services.IServices;

namespace ShopFlickerAPI.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;
        public EmailSender(IConfiguration config)
        {

            _config = config;

        }
        public Task SendEmailAsync(EmailDTO emailDTO)
        {
            var emailHost = _config.GetValue<string>("EmailConfigurations:EmailHost");
            var emailUserName = _config.GetValue<string>("EmailConfigurations:EmailUserName");
            var emailPassword = _config.GetValue<string>("EmailConfigurations:EmailPassword");

            var emailToSend = new MimeMessage();
            emailToSend.From.Add(MailboxAddress.Parse(emailUserName));
            emailToSend.To.Add(MailboxAddress.Parse(emailDTO.Email));
            emailToSend.Subject = emailDTO.Subject;
            emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = emailDTO.Body };

            using (var emailClient = new SmtpClient())
            {
                emailClient.Connect(emailHost, 587, MailKit.Security.SecureSocketOptions.StartTls);
                emailClient.Authenticate(emailUserName, emailPassword);
                emailClient.Send(emailToSend);
                emailClient.Disconnect(true);
            }
            return Task.CompletedTask;
        }
    }
}
