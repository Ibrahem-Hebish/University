namespace UniversityProject.Core.CQSR.Commands.DoctorCommands;

public record ChangeDoctorOffice(int DoctorId, string OfficeName, int DepId) : IRequest<Response<GetDoctorDto>> { }
