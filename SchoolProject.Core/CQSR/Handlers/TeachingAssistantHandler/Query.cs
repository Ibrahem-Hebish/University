namespace UniversityProject.Core.CQSR.Handlers.TeachingAssistantHandler;

public class Queries(
    ITeachingAssistantRepository teachingAssistantRepository,
    IMapper mapper)
    : ResponseHandler,
    IRequestHandler<GetTeachingAssistantByID, Response<GetTeachingAssistantDto>>,
    IRequestHandler<GetAllTeachingAssistants, Response<List<GetTeachingAssistantDto>>>
{
    public async Task<Response<GetTeachingAssistantDto>> Handle(GetTeachingAssistantByID request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return BadRequest<GetTeachingAssistantDto>("Id must be grater than 0");

        var TeachinAssistant = await teachingAssistantRepository.FindAsync(request.Id);

        if (TeachinAssistant == null)
            return NotFouned<GetTeachingAssistantDto>();

        var TeachingAssistantDto = mapper.Map<GetTeachingAssistantDto>(TeachinAssistant);

        return Success(TeachingAssistantDto);
    }

    public async Task<Response<List<GetTeachingAssistantDto>>> Handle(GetAllTeachingAssistants request, CancellationToken cancellationToken)
    {
        var TeachinAssistants = await teachingAssistantRepository.GetAllAsync();

        if (TeachinAssistants is null || TeachinAssistants.Count == 0)
            return NotFouned<List<GetTeachingAssistantDto>>("There is no teaching assistant");

        var TeachingAssistantDto = mapper.Map<List<GetTeachingAssistantDto>>(TeachinAssistants);

        return Success(TeachingAssistantDto);
    }
}
