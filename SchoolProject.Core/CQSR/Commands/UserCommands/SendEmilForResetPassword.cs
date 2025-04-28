namespace UniversityProject.Core.CQSR.Commands.UserCommands;

public record SendEmilForResetPassword(
    string Email)
    : IRequest<Response<string>>
{ }
