using UniversityProject.Core.CQSR.Commands.OfficeCommands;
using UniversityProject.Core.Dtos.OfficeDtos;

namespace UniversityProject.Core.CQSR.Handlers.OfficeHandler;


public class Commands(
    IOfficeRepository officeRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<DeleteOffice, Response<string>>,
    IRequestHandler<UpdateOfficeName, Response<GetOffice>>
{
    public async Task<Response<string>> Handle(DeleteOffice request, CancellationToken cancellationToken)
    {
        if (String.IsNullOrWhiteSpace(request.Name))
            return BadRequest<string>("Name is required");

        var office = await officeRepository.FindByNameAsync(request.Name);

        if (office is null)
            return NotFouned<string>("There is no office with this name");

        if (office.Users.Count > 0)
        {
            foreach (var user in office.Users)
            {
                user.Office = null;
            }
        }

        if (office.Doctors.Count > 0)
        {
            foreach (var doctor in office.Doctors)
            {
                doctor.Office = null;
            }
        }

        if (office.TeachingAssistants.Count > 0)
        {
            foreach (var teachingassistant in office.TeachingAssistants)
            {
                teachingassistant.Office = null;
            }
        }

        await officeRepository.DeleteAsync(office, request.Name);

        return Deleted<string>("Office is deleted successfully");
    }

    public async Task<Response<GetOffice>> Handle(UpdateOfficeName request, CancellationToken cancellationToken)
    {
        if (String.IsNullOrWhiteSpace(request.CurrentName))
            return BadRequest<GetOffice>("Current Name is required");

        if (String.IsNullOrWhiteSpace(request.NewName))
            return BadRequest<GetOffice>("New Name is required");

        var offices = await officeRepository.GetAllAsync();

        foreach (var exsistedoffice in offices)
        {
            if (exsistedoffice.Name == request.NewName)
                return BadRequest<GetOffice>("There is office with this name,please change the name");
        }

        var office = await officeRepository.FindByNameAsync(request.CurrentName);

        if (office is null)
            return NotFouned<GetOffice>("There is no office with this name");

        if (office.Users.Count > 0)
        {
            foreach (var user in office.Users)
            {
                user.OfficeName = request.NewName;
            }
        }

        if (office.Doctors.Count > 0)
        {
            foreach (var doctor in office.Doctors)
            {
                doctor.OfficeName = request.NewName;
            }
        }

        if (office.TeachingAssistants.Count > 0)
        {
            foreach (var teachingassistant in office.TeachingAssistants)
            {
                teachingassistant.OfficeName = request.NewName;
            }
        }

        office.Name = request.NewName;

        var result = await officeRepository.UpdateAsync(office, request.CurrentName);

        var officeDto = mapper.Map<GetOffice>(result);

        return Success(officeDto);
    }
}
