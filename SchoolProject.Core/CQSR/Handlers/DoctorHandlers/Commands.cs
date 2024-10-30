namespace UniversityProject.Core.CQSR.Handlers.DoctorHandlers;

public class Commands(
    IDoctorRepository doctorRepository,
    IOfficeRepository officeRepository,
    IDepartmentRepository departmentRepository,
    IMapper mapper)
    : ResponseHandler,
    IRequestHandler<DeleteDoctor, Response<string>>,
    IRequestHandler<ChangeDoctorOffice, Response<GetDoctorDto>>,
    IRequestHandler<AddNewDoctor, Response<string>>
{
    public async Task<Response<string>> Handle(
        DeleteDoctor request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return BadRequest<string>("Id must be greater than 0");

        var Doctor = await doctorRepository.FindAsync(request.Id);

        if (Doctor == null)
            return NotFouned<string>();

        var result = await doctorRepository.DeleteAsync(Doctor, request.Id);

        if (!result)
            return InternalServerError<string>();

        return Deleted<string>();
    }

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

    public async Task<Response<string>> Handle(AddNewDoctor request, CancellationToken cancellationToken)
    {
        var Department = await departmentRepository.FindAsync(request.DepartmentID);

        if (Department is null)
            return BadRequest<string>("There is no department with this id");

        var Doctor = mapper.Map<Doctor>(request);

        if (request.OfficeName is not null)
        {
            var Office = await officeRepository.FindByNameAsync(request.OfficeName);

            if (Office is null)
                return BadRequest<string>("There is no office with this name");

            var IsAvillible = await officeRepository.IsOfficeAvillibleForDoctor(Office, request.DepartmentID);

            if (IsAvillible != "Office is avillible")
                return BadRequest<string>(IsAvillible);

            Doctor.Office = Office;
        }

        await doctorRepository.AddAsync(Doctor);

        return Created<string>();
    }
}
