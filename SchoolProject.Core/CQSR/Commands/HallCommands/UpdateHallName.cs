using UniversityProject.Core.Dtos.HallDtos;

namespace UniversityProject.Core.CQSR.Commands.HallCommands;
public record UpdateHallName(string CurrentName, string NewName) : IRequest<Response<GetHall>> { }

