namespace UniversityProject.Core.CQSR.Queries.UserQueries;

public record GetUserById(
    int id)
    : IRequest<Response<GetUserDto>>
{ }

public record GetUsers
    : IRequest<Response<List<GetUserDto>>>
{ }
