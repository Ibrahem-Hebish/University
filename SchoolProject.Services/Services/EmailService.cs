using Microsoft.Extensions.Options;

namespace SchoolProject.Services.Services;

public class EmailService(
    IOptionsMonitor<SendEmailSetting> sendemailsetting, IConfiguration configuration)
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
                sendemailsetting.CurrentValue.ClientEmail,
                sendemailsetting.CurrentValue.Port,
                true);

            client.Authenticate(
                sendemailsetting.CurrentValue.Email,
                configuration["sendingemailpassword"]);

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
                sendemailsetting.CurrentValue.Name,
                sendemailsetting.CurrentValue.Email));

            mimeMessage.To.Add(new MailboxAddress(
                "Client",
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