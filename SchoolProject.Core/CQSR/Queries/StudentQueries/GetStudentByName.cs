namespace UniversityProject.Core.CQSR.Queries.StudentQueries;

public record GetStudentByName(
    string Name)
    : IRequest<Response<GetStudentDto>>
{ }
