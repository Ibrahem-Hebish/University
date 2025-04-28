using UniversityProject.Core.Dtos.HallDtos;

namespace UniversityProject.Core.CQSR.Queries.HallQueries;

public record GetAllHalls() : IRequest<Response<List<GetHall>>> { }
