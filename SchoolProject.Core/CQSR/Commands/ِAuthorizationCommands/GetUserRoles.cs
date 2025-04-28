namespace UniversityProject.Core.CQSR.Commands.RolesCommands;

public record GetUserRoles(
    int Id)
    : IRequest<Response<ManageUserRoles>>
{ }
