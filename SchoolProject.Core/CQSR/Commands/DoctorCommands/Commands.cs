namespace UniversityProject.Core.CQSR.Commands.DoctorCommands;

public record DeleteDoctor(int Id) : IRequest<Response<string>> { }

public record ChangeDoctorOffice(int DoctorId, string OfficeName, int DepId) : IRequest<Response<GetDoctorDto>> { }
