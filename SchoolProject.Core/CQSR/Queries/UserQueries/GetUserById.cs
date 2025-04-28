namespace UniversityProject.Core.CQSR.Queries.UserQueries;

public record GetUserById(
    int Id)
    : IRequest<Response<GetUserDto>>
{ }
