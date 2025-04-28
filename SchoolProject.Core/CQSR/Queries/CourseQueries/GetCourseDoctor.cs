namespace UniversityProject.Core.CQSR.Queries.CourseQueries;
public record GetCourseDoctor(int Id) : IRequest<Response<GetDoctorDto>> { }
