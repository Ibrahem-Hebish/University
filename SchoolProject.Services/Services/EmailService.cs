using MailKit.Security;

namespace UniversityProject.Services.Services;

public class EmailService(
    IOptions<SendEmailSetting> sendemailsetting, IConfiguration configuration)
    : IEmailService
{
    public async Task<string> SendEmailAsync(
        string email,
        string message,
        string subject)
    {
        try
        {
            using var client = new SmtpClient();

            await client.ConnectAsync(
                sendemailsetting.Value.ClientEmail,
                sendemailsetting.Value.Port,
                SecureSocketOptions.StartTls);

            client.Authenticate(
                sendemailsetting.Value.Email,
                configuration["SENDING_EMAIL_PASSWORD"]);

            var bodyBuilder = new BodyBuilder()
            {
                HtmlBody = message,
                TextBody = $"Welcome {email}"
            };

            var mimeMessage = new MimeMessage
            {
                Body = bodyBuilder.ToMessageBody(),
                Subject = subject
            };

            mimeMessage.From.Add(new MailboxAddress(
                sendemailsetting.Value.Name,
                sendemailsetting.Value.Email));

            mimeMessage.To.Add(new MailboxAddress(
                email[..email.IndexOf('@')],
                email));

            await client.SendAsync(mimeMessage);

            await client.DisconnectAsync(true);

            return "Success";

        }
        catch
        {
            return "Fail";
        }
    }
}