namespace UniversityProject.Core.CQSR.Queries.DoctorQueries;

public record GetAllDoctors : IRequest<Response<List<GetDoctorDto>>> { }
public record GetDoctor(int id) : IRequest<Response<GetDoctorDto>> { }
public record GetDoctorCourses(int id) : IRequest<Response<List<GetCourseDto>>> { }
