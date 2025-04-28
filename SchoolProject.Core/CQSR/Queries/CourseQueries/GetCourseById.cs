namespace UniversityProject.Core.CQSR.Queries.CourseQueries;

public record GetCourseById(int Id) : IRequest<Response<GetCourseDto>> { }
