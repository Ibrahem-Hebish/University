namespace UniversityProject.Core.CQSR.Commands.OfficeCommands;

public record DeleteOffice(string Name) : IRequest<Response<string>> { }

