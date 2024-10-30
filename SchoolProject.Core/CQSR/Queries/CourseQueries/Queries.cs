namespace UniversityProject.Core.CQSR.Queries.CourseQueries;

public record GetCourseById(int Id) : IRequest<Response<GetCourseDto>> { }
public record GetAllCourses : IRequest<Response<List<GetCourseDto>>> { }
public record GetAllCoursesInASpecificTerm(int Level, int Term) : IRequest<Response<List<GetCourseDto>>> { }
public record GetCourseDoctor(int Id) : IRequest<Response<GetDoctorDto>> { }
