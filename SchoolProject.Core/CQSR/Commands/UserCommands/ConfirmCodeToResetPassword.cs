namespace UniversityProject.Core.CQSR.Commands.UserCommands;

public record ConfirmCodeToResetPassword(
    string Code, string Email)
    : IRequest<Response<string>>
{ }
