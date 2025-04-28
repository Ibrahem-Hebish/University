namespace UniversityProject.Core.CQSR.Queries.StudentQueries;

public record GroupStudentsByDep(
    string Name)
    : IRequest<Response<List<GetStudentDto>>>
{ }
