namespace SchoolProject.Core.CQSR.Commands.EmailCommands;

public class SendEmailCommand
    : IRequest<Response<string>>
{
    public string Email { get; set; }

    public string message { get; set; }

    public string subject { get; set; }
}
