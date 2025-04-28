using UniversityProject.Core.CQSR.Queries.SectionQuiries;
using UniversityProject.Core.Dtos.SectionDtos;

namespace UniversityProject.Core.CQSR.Handlers.SectionHandler.Queries;

public class GetAllSectionsInASpecificTermHandler(ISectionRepository sectionRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetAllSectionsInASpecificTerm, Response<List<GetSectionDto>>>

{
    public async Task<Response<List<GetSectionDto>>> Handle(GetAllSectionsInASpecificTerm request, CancellationToken cancellationToken)
    {
        if (request.Level < 1 || request.Level > 4)
            return BadRequest<List<GetSectionDto>>("Level must be from 1 to 4");

        if (request.Term < 1 || request.Term > 2)
            return BadRequest<List<GetSectionDto>>("Term must be 1 or 2");

        var Sections = await sectionRepository.GetAllWhere(s =>
                                 s.Level == request.Level && s.Term == request.Term);

        if (Sections is null || !Sections.Any())
            return NotFouned<List<GetSectionDto>>("There is no sections");

        var SectionsDto = mapper.Map<List<GetSectionDto>>(Sections);

        return Success(SectionsDto);
    }

}

