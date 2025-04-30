namespace UniversityProject.Core.CQSR.Commands.AuthonticationCommands;

public record ConfirmEmailCommand
    : IRequest<Response<string>>
{ }
