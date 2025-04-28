namespace UniversityProject.Core.CQSR.Handlers.TeachingAssistantHandler.Commands;

public class DeleteTeachingAssistantHandler(ITeachingAssistantRepository teachingAssistantRepository,
    IStudentTeachingAssistantsRepository studentTeachingAssistantsRepository,
    ISectionRepository sectionRepository) :
    ResponseHandler
    , IRequestHandler<DeleteTeachingAssistant, Response<string>>
{
    public async Task<Response<string>> Handle(DeleteTeachingAssistant request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return BadRequest<string>("Id must be grater than 0");

        var TeachingAssistant = await teachingAssistantRepository.FindAsync(request.Id);

        if (TeachingAssistant is null)
            return NotFouned<string>("There is no teaching assistant with this id");

        var Sections = await sectionRepository.GetAllWhere(s => s.TeachingAssistantId == request.Id);
        // var Sections = await sectionRepository.GetAllAsync();
        foreach (var section in Sections)
            section.TeachingAssistantId = null;


        await sectionRepository.SaveChangesAsync();

        var StudentTeachingAssistants = await studentTeachingAssistantsRepository.GetAllWhere(
            st => st.TeachingAssistantId == request.Id);

        if (StudentTeachingAssistants is not null && StudentTeachingAssistants.Any())
            await studentTeachingAssistantsRepository.DeleteRangeAsync(StudentTeachingAssistants);

        await teachingAssistantRepository.DeleteAsync(TeachingAssistant, request.Id);

        return Deleted<string>();
    }

}
