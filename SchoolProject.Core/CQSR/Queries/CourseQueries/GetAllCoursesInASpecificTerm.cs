namespace UniversityProject.Core.CQSR.Queries.CourseQueries;

public record GetAllCoursesInASpecificTerm(int Level, int Term) : IRequest<Response<List<GetCourseDto>>> { }
