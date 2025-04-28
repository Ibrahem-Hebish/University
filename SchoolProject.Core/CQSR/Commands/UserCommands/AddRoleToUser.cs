namespace UniversityProject.Core.CQSR.Commands.UserCommands;

public record AddRoleToUser(
    string Username, string Role)
    : IRequest<Response<bool>>
{ }
