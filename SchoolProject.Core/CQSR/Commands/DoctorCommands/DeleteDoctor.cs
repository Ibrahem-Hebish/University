namespace UniversityProject.Core.CQSR.Commands.DoctorCommands;

public record DeleteDoctor(int Id) : IRequest<Response<string>> { }
