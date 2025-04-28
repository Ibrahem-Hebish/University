namespace UniversityProject.Core.CQSR.Queries.StudentQueries;

public record GetStudentCourses(int Id) : IRequest<Response<List<GetCourseDto>>> { }
