namespace UniversityProject.Core.CQSR.Commands.RolesCommands;

public record AddRoleCommand(
    string Name)
    : IRequest<Response<string>>
{ }
