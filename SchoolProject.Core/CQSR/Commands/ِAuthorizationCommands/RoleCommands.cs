namespace SchoolProject.Core.CQSR.Commands.RolesCommands;

public record AddRoleCommand(
    string name)
    : IRequest<Response<string>>
{ }

public record DeleteRole(
    int id)
    : IRequest<Response<string>>
{ }

public record UpdateRole(
    string currentName, string newName)
    : IRequest<Response<string>>
{ }

public record GetUserRoles(
    int id)
    : IRequest<Response<ManageUserRoles>>
{ }

public class Updateuserclaims
    : Manageuserclaims, IRequest<Response<string>>
{ }
