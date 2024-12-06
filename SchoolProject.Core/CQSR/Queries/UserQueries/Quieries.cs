namespace UniversityProject.Core.CQSR.Queries.UserQueries;

public record GetUserById(
    int Id)
    : IRequest<Response<GetUserDto>>
{ }

public record GetUsers
    : IRequest<Response<List<GetUserDto>>>
{ }

public record CheckIfEmailExsist(string Email) : IRequest<Response<bool>> { }
