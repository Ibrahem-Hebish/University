using UniversityProject.Core.Dtos.SectionDtos;

namespace UniversityProject.Core.CQSR.Queries.SectionQuiries;

public record GetSectionById(int Id) : IRequest<Response<GetSectionDto>> { }

