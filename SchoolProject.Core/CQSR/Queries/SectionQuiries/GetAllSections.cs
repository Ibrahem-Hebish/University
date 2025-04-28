using UniversityProject.Core.Dtos.SectionDtos;

namespace UniversityProject.Core.CQSR.Queries.SectionQuiries;

public record GetAllSections : IRequest<Response<List<GetSectionDto>>> { }

