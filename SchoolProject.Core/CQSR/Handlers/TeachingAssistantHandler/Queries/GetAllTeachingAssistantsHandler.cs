namespace UniversityProject.Core.CQSR.Handlers.TeachingAssistantHandler.Queries;

public class GetAllTeachingAssistantsHandler(
    ITeachingAssistantRepository teachingAssistantRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetAllTeachingAssistants, Response<List<GetTeachingAssistantDto>>>
{
    public async Task<Response<List<GetTeachingAssistantDto>>> Handle(GetAllTeachingAssistants request, CancellationToken cancellationToken)
    {
        var TeachinAssistants = await teachingAssistantRepository.GetAllAsync();

        if (TeachinAssistants is null || !TeachinAssistants.Any())
            return NotFouned<List<GetTeachingAssistantDto>>("There is no teaching assistant");

        var TeachingAssistantDto = mapper.Map<List<GetTeachingAssistantDto>>(TeachinAssistants);

        return Success(TeachingAssistantDto);
    }

}


