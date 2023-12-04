using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;


namespace Musify.MVC.Infrastructure.MailService
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;
        private readonly Serilog.ILogger _logger;

        public EmailService(IOptions<EmailSettings> settings, Serilog.ILogger logger)
        {
            _settings = settings.Value;
            _logger = logger;
        }
        public async Task SendEmail(Email email)
        {

            var message = new MimeMessage();
            //email setup
            message.From.Add(new MailboxAddress(_settings.FromName, _settings.FromAddress));
            message.To.Add(MailboxAddress.Parse(email.To));
            message.Subject = email.Subject;

            // build email form
            var builder = new BodyBuilder();
            builder.HtmlBody = email.Body;
            message.Body = builder.ToMessageBody();

            //email configration 
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(_settings.FromAddress, _settings.APIKey);
                await smtp.SendAsync(message);
                //_logger.Error("Email Sent Successfully");
            }
            catch
            {
                Directory.CreateDirectory("mailssave");
                var emailsavefile = string.Format(@"mailssave/{0}.eml", Guid.NewGuid());
                await message.WriteToAsync(emailsavefile);
            }

            smtp.Disconnect(true);
        }

    }
}

