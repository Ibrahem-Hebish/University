using UniversityProject.Core.CQSR.Queries.SectionQuiries;
using UniversityProject.Core.Dtos.SectionDtos;

namespace UniversityProject.Core.CQSR.Handlers.SectionHandler.Queries;

public class GetAllSectionsHandler(ISectionRepository sectionRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetAllSections, Response<List<GetSectionDto>>>

{
    public async Task<Response<List<GetSectionDto>>> Handle(GetAllSections request, CancellationToken cancellationToken)
    {
        var Sections = await sectionRepository.GetAllAsync();

        if (Sections is null || !Sections.Any())
            return NotFouned<List<GetSectionDto>>();

        var SectionsDto = mapper.Map<List<GetSectionDto>>(Sections);

        return Success(SectionsDto);
    }

}

