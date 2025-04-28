namespace UniversityProject.Core.CQSR.Commands.HallCommands;

public record DeleteHall(string Name) : IRequest<Response<string>> { }

