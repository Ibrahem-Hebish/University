namespace UniversityProject.Services.AbstractionServices;

public interface IEmailService
{
    public Task<string> SendEmailAsync(string email,
                                       string message,
                                       string Course);
}
