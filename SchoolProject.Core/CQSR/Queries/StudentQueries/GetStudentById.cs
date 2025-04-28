namespace UniversityProject.Core.CQSR.Queries.StudentQueries;

public record GetStudentById(
    int Id)
    : IRequest<Response<GetStudentDto>>
{ }
