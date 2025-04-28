namespace UniversityProject.Core.CQSR.Commands.RolesCommands;

public record DeleteRole(
    int Id)
    : IRequest<Response<string>>
{ }
