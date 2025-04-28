namespace UniversityProject.Core.CQSR.Queries.CourseQueries;

public record GetAllCourses : IRequest<Response<List<GetCourseDto>>> { }
