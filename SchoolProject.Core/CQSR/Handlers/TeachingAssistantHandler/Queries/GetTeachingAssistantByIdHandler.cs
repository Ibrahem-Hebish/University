namespace UniversityProject.Core.CQSR.Handlers.TeachingAssistantHandler.Queries;

public class GetTeachingAssistantByIdHandler(
    ITeachingAssistantRepository teachingAssistantRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetTeachingAssistantByID, Response<GetTeachingAssistantDto>>
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

}


