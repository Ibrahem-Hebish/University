using UniversityProject.Core.Dtos.SectionDtos;

namespace UniversityProject.Core.CQSR.Queries.SectionQuiries;

public record GetAllSectionsInASpecificTerm(int Level, int Term) : IRequest<Response<List<GetSectionDto>>> { }

