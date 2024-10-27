namespace UniversityProject.Core.CQSR.Queries.DoctorQueries;

public record GetAllDoctors : IRequest<Response<List<GetDoctorDto>>> { }
public record GetDoctor(int id) : IRequest<Response<GetDoctorDto>> { }
public record GetDoctorSubjects(int id) : IRequest<Response<List<GetSubjectDto>>> { }
