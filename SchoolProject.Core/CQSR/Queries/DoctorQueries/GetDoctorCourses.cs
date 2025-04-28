namespace UniversityProject.Core.CQSR.Queries.DoctorQueries;
public record GetDoctorCourses(int id) : IRequest<Response<List<GetCourseDto>>> { }
