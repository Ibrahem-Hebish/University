using UniversityProject.Core.Dtos.HallDtos;

namespace UniversityProject.Core.CQSR.Commands.HallCommands;

public record DeleteHall(string Name) : IRequest<Response<string>> { }
public record UpdateHallName(string CurrentName, string NewName) : IRequest<Response<GetHall>> { }

