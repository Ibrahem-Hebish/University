using UniversityProject.Core.CQSR.Queries.OfficeQueries;
using UniversityProject.Core.Dtos.OfficeDtos;

namespace UniversityProject.Core.CQSR.Handlers.OfficeHandler;


public class Queries(
    IOfficeRepository officeRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetOfficeById, Response<GetOffice>>,
    IRequestHandler<GetAllOffices, Response<List<GetOffice>>>,
    IRequestHandler<GetStaffInOffice, Response<OfficeStaff>>
{
    public async Task<Response<GetOffice>> Handle(GetOfficeById request, CancellationToken cancellationToken)
    {
        if (String.IsNullOrWhiteSpace(request.Name))
            return BadRequest<GetOffice>("Name is required");

        var office = await officeRepository.FindByNameAsync(request.Name);

        if (office is null)
            return NotFouned<GetOffice>("There is no office with this name");

        var officeDto = mapper.Map<GetOffice>(office);

        return Success(officeDto);
    }

    public async Task<Response<List<GetOffice>>> Handle(GetAllOffices request, CancellationToken cancellationToken)
    {
        var offices = await officeRepository.GetAllAsync();

        if (offices.Count == 0)
            return NotFouned<List<GetOffice>>("There are no labs in the system");

        var officesDto = mapper.Map<List<GetOffice>>(offices.ToList());


        return Success(officesDto);
    }

    public async Task<Response<OfficeStaff>> Handle(GetStaffInOffice request, CancellationToken cancellationToken)
    {
        if (String.IsNullOrWhiteSpace(request.Name))
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