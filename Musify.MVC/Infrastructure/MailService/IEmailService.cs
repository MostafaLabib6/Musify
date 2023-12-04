namespace Musify.MVC.Infrastructure.MailService;

public interface IEmailService
{
    public Task SendEmail(Email email);
}
