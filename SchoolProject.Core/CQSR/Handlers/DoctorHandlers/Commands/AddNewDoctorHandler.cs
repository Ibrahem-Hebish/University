namespace UniversityProject.Core.CQSR.Handlers.DoctorHandlers.Commands;

public class AddNewDoctorHandler(IDoctorRepository doctorRepository,
    IOfficeRepository officeRepository,
    IDepartmentRepository departmentRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<AddNewDoctor, Response<string>>
{
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
