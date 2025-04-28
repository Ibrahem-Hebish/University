namespace UniversityProject.Core.CQSR.Queries.UserQueries;

public record GetUsers
    : IRequest<Response<List<GetUserDto>>>
{ }
