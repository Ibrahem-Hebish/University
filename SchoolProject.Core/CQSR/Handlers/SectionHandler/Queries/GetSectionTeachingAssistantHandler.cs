using UniversityProject.Core.CQSR.Queries.SectionQuiries;

namespace UniversityProject.Core.CQSR.Handlers.SectionHandler.Queries;

public class GetSectionTeachingAssistantHandler(ISectionRepository sectionRepository,
    ITeachingAssistantRepository teachingAssistantRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetSectionTeachingAssistant, Response<GetTeachingAssistantDto>>

{
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

}

