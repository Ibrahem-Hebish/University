namespace UniversityProject.Core.CQSR.Commands.RolesCommands;

public record UpdateRole(
    string CurrentName, string NewName)
    : IRequest<Response<string>>
{ }
