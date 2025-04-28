namespace UniversityProject.Core.CQSR.Queries.StudentQueries;

public record GroupStudentsByCourse(
    string Name)
    : IRequest<Response<List<GetStudentDto>>>
{ }
