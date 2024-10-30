namespace UniversityProject.Core.CQSR.Commands.RolesCommands;

public record AddRoleCommand(
    string Name)
    : IRequest<Response<string>>
{ }

public record DeleteRole(
    int Id)
    : IRequest<Response<string>>
{ }

public record UpdateRole(
    string CurrentName, string NewName)
    : IRequest<Response<string>>
{ }

public record GetUserRoles(
    int Id)
    : IRequest<Response<ManageUserRoles>>
{ }

public class Updateuserclaims
    : Manageuserclaims, IRequest<Response<string>>
{ }
