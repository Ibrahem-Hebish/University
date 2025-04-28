namespace UniversityProject.Core.CQSR.Handlers.TeachingAssistantHandler.Commands;

public class AddTeachingAssistantHandler(ITeachingAssistantRepository teachingAssistantRepository,
    IDepartmentRepository departmentRepository,
    IOfficeRepository officeRepository,
    IMapper mapper) :
    ResponseHandler
    , IRequestHandler<AddTeachingAssistant, Response<string>>
{
    public async Task<Response<string>> Handle(AddTeachingAssistant request, CancellationToken cancellationToken)
    {
        var Department = await departmentRepository.FindAsync(request.DepartmentID);

        if (Department is null)
            return BadRequest<string>("There is no department with this id");

        var TeachingAssistant = mapper.Map<TeachingAssistant>(request);

        if (request.OfficeName is not null)
        {
            var Office = await officeRepository.FindByNameAsync(request.OfficeName);

            if (Office is null)
                return BadRequest<string>("There is no office with this name");

            var IsAvillible = await officeRepository
                                            .IsOfficeAvillibleForTeachingAssistant(
                                                             Office, request.DepartmentID);

            if (IsAvillible != "Office is avillible")
                return BadRequest<string>(IsAvillible);

            TeachingAssistant.Office = Office;
        }

        await teachingAssistantRepository.AddAsync(TeachingAssistant);

        return Created<string>();
    }

}
