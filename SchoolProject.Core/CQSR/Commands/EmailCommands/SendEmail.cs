namespace UniversityProject.Core.CQSR.Commands.EmailCommands;

public class SendEmailCommand
    : IRequest<Response<string>>
{
    public string Email { get; set; }

    public string message { get; set; }

    public string Course { get; set; }
}
