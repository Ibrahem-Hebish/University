namespace UniversityProject.Core.CQSR.Queries.StudentQueries;

public record GetAllStudents()
    : IRequest<Response<List<GetStudentDto>>>
{ }
