using UniversityProject.Core.Dtos.HallDtos;

namespace UniversityProject.Core.CQSR.Queries.HallQueries;

public record GetHallById(string Name) : IRequest<Response<GetHall>> { }
