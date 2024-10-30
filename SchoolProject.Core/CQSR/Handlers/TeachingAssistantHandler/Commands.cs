using UniversityProject.Core.CQSR.Commands.Teaching_Assistants_Commands;

namespace UniversityProject.Core.CQSR.Handlers.TeachingAssistantHandler;

public class Commands(
    ITeachingAssistantRepository teachingAssistantRepository
    , IOfficeRepository officeRepository,
    IDepartmentRepository departmentRepository,
    ISectionRepository sectionRepository,
    IStudentTeachingAssistantsRepository studentTeachingAssistantsRepository,
    IMapper mapper)
    : ResponseHandler
    , IRequestHandler<ChangeTeachingAssistantOffice, Response<GetTeachingAssistantDto>>,
    IRequestHandler<DeleteTeachingAssistant, Response<string>>
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

        if (StudentTeachingAssistants is not null && StudentTeachingAssistants.Count > 0)
            await studentTeachingAssistantsRepository.DeleteRangeAsync(StudentTeachingAssistants);

        await teachingAssistantRepository.DeleteAsync(TeachingAssistant, request.Id);

        return Deleted<string>();
    }
}
