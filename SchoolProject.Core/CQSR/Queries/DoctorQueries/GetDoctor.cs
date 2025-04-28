namespace UniversityProject.Core.CQSR.Queries.DoctorQueries;

public record GetDoctor(int id) : IRequest<Response<GetDoctorDto>> { }
