namespace UniversityProject.Core.CQSR.Commands.UserCommands;

public record ResetPassword(
    string Email, string Password, string Confirmpasswod)
    : IRequest<Response<string>>
{ }
