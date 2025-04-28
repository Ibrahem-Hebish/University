using UniversityProject.Core.CQSR.Queries.OfficeQueries;
using UniversityProject.Core.Dtos.OfficeDtos;

namespace UniversityProject.Core.CQSR.Handlers.OfficeHandler.Queries;

public class GetStaffInOfficeHandler(IOfficeRepository officeRepository) :
    ResponseHandler,
    IRequestHandler<GetStaffInOffice, Response<OfficeStaff>>
{
    public async Task<Response<OfficeStaff>> Handle(GetStaffInOffice request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return BadRequest<OfficeStaff>("Name is required");

        var office = await officeRepository.FindByNameAsync(request.Name);

        if (office is null)
            return NotFouned<OfficeStaff>("There is no office with this name");

        OfficeStaff officeStaff = new();

        if (office.For == "Doctors")
        {
            officeStaff.For = office.For;
            foreach (var doctor in office.Doctors)
                officeStaff.staffs.Add(new Staff { Name = doctor.Name, Id = doctor.Id });
        }
        else if (office.For == "Teaching Assistants")
        {
            officeStaff.For = office.For;
            foreach (var teachingAssistant in office.TeachingAssistants)
                officeStaff.staffs.Add(
                    new Staff { Name = teachingAssistant.Name, Id = teachingAssistant.Id });
        }

        else
        {
            officeStaff.For = office.For;
            foreach (var user in office.Users)
                officeStaff.staffs.Add(new Staff { Name = user.UserName!, Id = user.Id });
        }

        return Success(officeStaff);
    }

}



