namespace UniversityProject.Core.CQSR.Commands.UserCommands;

public class ChangePassword
    : IRequest<Response<string>>
{
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Newpassword { get; set; } = null!;

    public string Confirmnewpassword { get; set; } = null!;
}
