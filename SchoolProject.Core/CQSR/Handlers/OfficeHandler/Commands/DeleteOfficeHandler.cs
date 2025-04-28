using UniversityProject.Core.CQSR.Commands.OfficeCommands;

namespace UniversityProject.Core.CQSR.Handlers.OfficeHandler.Commands;

public class DeleteOfficeHandler(IOfficeRepository officeRepository) :
    ResponseHandler,
    IRequestHandler<DeleteOffice, Response<string>>
{
    public async Task<Response<string>> Handle(DeleteOffice request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
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

}



