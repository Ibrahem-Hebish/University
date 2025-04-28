namespace UniversityProject.Core.CQSR.Queries.DoctorQueries;

public record GetAllDoctors : IRequest<Response<List<GetDoctorDto>>> { }
