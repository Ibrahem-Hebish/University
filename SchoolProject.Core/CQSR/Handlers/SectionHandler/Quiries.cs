using UniversityProject.Core.CQSR.Queries.SectionQuiries;
using UniversityProject.Core.Dtos.SectionDtos;

namespace UniversityProject.Core.CQSR.Handlers.SectionHandler;

public class Quiries(
    ISectionRepository sectionRepository,
    ITeachingAssistantRepository teachingAssistantRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetSectionById, Response<GetSectionDto>>,
    IRequestHandler<GetAllSections, Response<List<GetSectionDto>>>,
    IRequestHandler<GetAllSectionsInASpecificTerm, Response<List<GetSectionDto>>>,
    IRequestHandler<GetSectionTeachingAssistant, Response<GetTeachingAssistantDto>>

{
    public async Task<Response<GetSectionDto>> Handle(GetSectionById request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return BadRequest<GetSectionDto>("Id must be grater than 0");

        var Section = await sectionRepository.FindAsync(request.Id);

        if (Section is null)
            return NotFouned<GetSectionDto>("There is no section with this id");

        var SectionDto = mapper.Map<GetSectionDto>(Section);

        return Success(SectionDto);
    }

    public async Task<Response<List<GetSectionDto>>> Handle(GetAllSections request, CancellationToken cancellationToken)
    {
        var Sections = await sectionRepository.GetAllAsync();

        if (Sections is null || Sections.Count == 0)
            return NotFouned<List<GetSectionDto>>();

        var SectionsDto = mapper.Map<List<GetSectionDto>>(Sections);

        return Success(SectionsDto);
    }

    public async Task<Response<GetTeachingAssistantDto>> Handle(GetSectionTeachingAssistant request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return BadRequest<GetTeachingAssistantDto>("Id must be grater than 0");

        var Section = await sectionRepository.FindAsync(request.Id);

        if (Section is null)
            return NotFouned<GetTeachingAssistantDto>("There is no section with this id");

        if (Section.TeachingAssistantId is null)
            return BadRequest<GetTeachingAssistantDto>("There is no teaching assistant attached to this section");

        var TeachingAssistant = await teachingAssistantRepository.FindAsync((int)Section.TeachingAssistantId);

        var TeachingAssistantDto = mapper.Map<GetTeachingAssistantDto>(TeachingAssistant);

        return Success(TeachingAssistantDto);

    }

    public async Task<Response<List<GetSectionDto>>> Handle(GetAllSectionsInASpecificTerm request, CancellationToken cancellationToken)
    {
        if (request.Level < 1 || request.Level > 4)
            return BadRequest<List<GetSectionDto>>("Level must be from 1 to 4");

        if (request.Term < 1 || request.Term > 2)
            return BadRequest<List<GetSectionDto>>("Term must be 1 or 2");

        var Sections = await sectionRepository.GetAllWhere(s =>
                                 s.Level == request.Level && s.Term == request.Term);

        if (Sections is null || Sections.Count == 0)
            return NotFouned<List<GetSectionDto>>("There is no sections");

        var SectionsDto = mapper.Map<List<GetSectionDto>>(Sections);

        return Success(SectionsDto);
    }
}
