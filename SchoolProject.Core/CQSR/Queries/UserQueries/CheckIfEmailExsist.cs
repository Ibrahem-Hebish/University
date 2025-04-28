namespace UniversityProject.Core.CQSR.Queries.UserQueries;

public record CheckIfEmailExsist(string Email) : IRequest<Response<bool>> { }
