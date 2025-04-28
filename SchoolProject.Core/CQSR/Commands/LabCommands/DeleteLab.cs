namespace UniversityProject.Core.CQSR.Commands.LabCommands;

public record DeleteLab(string Name) : IRequest<Response<string>> { }
