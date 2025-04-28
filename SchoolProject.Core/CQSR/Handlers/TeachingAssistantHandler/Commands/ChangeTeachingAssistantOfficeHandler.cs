namespace UniversityProject.Core.CQSR.Handlers.TeachingAssistantHandler.Commands;

public class ChangeTeachingAssistantOfficeHandler(ITeachingAssistantRepository teachingAssistantRepository,
    IDepartmentRepository departmentRepository,
    IOfficeRepository officeRepository,
    IMapper mapper) :
    ResponseHandler
    , IRequestHandler<ChangeTeachingAssistantOffice, Response<GetTeachingAssistantDto>>
{
    public async Task<Response<GetTeachingAssistantDto>> Handle(ChangeTeachingAssistantOffice request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0 || request.DepId <= 0)
            return BadRequest<GetTeachingAssistantDto>("Id must be grater than 0");

        var TeachingAssistant = await teachingAssistantRepository.FindAsync(request.Id);

        if (TeachingAssistant is null)
            return NotFouned<GetTeachingAssistantDto>();

        var Department = await departmentRepository.FindAsync(request.DepId);

        if (Department is null)
            return NotFouned<GetTeachingAssistantDto>("There is no department with this id");

        var Office = await officeRepository.FindByNameAsync(request.OfficeName);

        if (Office is null)
            return NotFouned<GetTeachingAssistantDto>("There is no office with this id");

        var IsOfficeAvillible = await officeRepository.IsOfficeAvillibleForTeachingAssistant(Office, request.DepId);

        if (IsOfficeAvillible != "Office is avillible")
            return BadRequest<GetTeachingAssistantDto>(IsOfficeAvillible);
        TeachingAssistant.OfficeName = request.OfficeName;

        await teachingAssistantRepository.UpdateAsync(TeachingAssistant, request.Id);

        var TeachingAssistantDto = mapper.Map<GetTeachingAssistantDto>(TeachingAssistant);

        return Success(TeachingAssistantDto, "Changing office is done");

    }

}
