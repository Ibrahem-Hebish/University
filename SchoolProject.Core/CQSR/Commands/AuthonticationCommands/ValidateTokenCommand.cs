namespace UniversityProject.Core.CQSR.Commands.AuthonticationCommands;

public record ValidateTokenCommand(
    string AccessToken)
    : IRequest<Response<string>>
{ }
