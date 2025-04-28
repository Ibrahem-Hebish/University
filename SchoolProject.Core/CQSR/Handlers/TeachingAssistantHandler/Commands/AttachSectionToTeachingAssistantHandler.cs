namespace UniversityProject.Core.CQSR.Handlers.TeachingAssistantHandler.Commands;

public class AttachSectionToTeachingAssistantHandler(ITeachingAssistantRepository teachingAssistantRepository,
    ISectionRepository sectionRepository) :
    ResponseHandler
    , IRequestHandler<AttachSectionToTeachingAssistant, Response<string>>
{
    public async Task<Response<string>> Handle(AttachSectionToTeachingAssistant request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0 || request.SectionId <= 0)
            return BadRequest<string>("Id must be grater than 0");

        var TeachingAssistant = await teachingAssistantRepository.FindAsync(request.Id);

        if (TeachingAssistant is null)
            return NotFouned<string>("There is no teaching assistant with this id");

        var Section = await sectionRepository.FindAsync(request.SectionId);

        if (Section is null)
            return NotFouned<string>("There is no Section with this id");

        if (Section.TeachingAssistantId is not null)
            return BadRequest<string>("This section is attached to another one");

        TeachingAssistant.Sections.Add(Section);

        await teachingAssistantRepository.UpdateAsync(TeachingAssistant, request.Id);

        return Success($"Attaching section to {TeachingAssistant.Name} got sucssefully");

    }

}