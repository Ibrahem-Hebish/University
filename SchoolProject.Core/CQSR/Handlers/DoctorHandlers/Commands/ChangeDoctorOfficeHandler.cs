namespace UniversityProject.Core.CQSR.Handlers.DoctorHandlers.Commands;

public class ChangeDoctorOfficeHandler(IDoctorRepository doctorRepository,
    IOfficeRepository officeRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<ChangeDoctorOffice, Response<GetDoctorDto>>
{
    public async Task<Response<GetDoctorDto>> Handle(
         ChangeDoctorOffice request, CancellationToken cancellationToken)
    {
        if (request.DoctorId <= 0 || request.DepId <= 0)
            return BadRequest<GetDoctorDto>("Id must be greater than 0");

        var Doctor = await doctorRepository.FindAsync(request.DoctorId);

        if (Doctor is null)
            return NotFouned<GetDoctorDto>("There is no doctor with this id");

        var Office = await officeRepository.FindByNameAsync(request.OfficeName);

        if (Office is null)
            return BadRequest<GetDoctorDto>("There is no office with that name");

        var IsOfficeAvillible = await officeRepository.IsOfficeAvillibleForDoctor(Office, request.DepId);

        if (IsOfficeAvillible != "Office is avillible")
            return BadRequest<GetDoctorDto>(IsOfficeAvillible);

        Doctor.Office = Office;

        await doctorRepository.UpdateAsync(Doctor, request.DoctorId);

        var DoctorDto = mapper.Map<GetDoctorDto>(Doctor);

        return Success(DoctorDto);
    }
}
