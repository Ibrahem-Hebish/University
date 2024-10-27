namespace UniversityProject.Core.CQSR.Handlers.DoctorHandlers;

public class QueriesHandler(IDoctorRepository doctorRepository, IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetDoctor, Response<GetDoctorDto>>,
    IRequestHandler<GetAllDoctors, Response<List<GetDoctorDto>>>,
    IRequestHandler<GetDoctorSubjects, Response<List<GetSubjectDto>>>
{
    public async Task<Response<GetDoctorDto>> Handle(GetDoctor request, CancellationToken cancellationToken)
    {
        if (request.id <= 0)
            return BadRequest<GetDoctorDto>("Id must be greater than 0");

        var Doctor = await doctorRepository.FindAsync(request.id);

        if (Doctor == null)
            return NotFouned<GetDoctorDto>();

        var DoctorDto = mapper.Map<GetDoctorDto>(Doctor);

        return Success(DoctorDto);
    }
    public async Task<Response<List<GetDoctorDto>>> Handle(GetAllDoctors request, CancellationToken cancellationToken)
    {
        var Doctors = await doctorRepository.GetAllAsync();

        if (Doctors is null || Doctors.Count == 0)
            return NotFouned<List<GetDoctorDto>>();

        var DoctorsDtos = mapper.Map<List<GetDoctorDto>>(Doctors);

        return Success(DoctorsDtos);
    }

    public async Task<Response<List<GetSubjectDto>>> Handle(GetDoctorSubjects request, CancellationToken cancellationToken)
    {
        if (request.id <= 0)
            return BadRequest<List<GetSubjectDto>>("Id must be greater than 0");

        var Doctor = await doctorRepository.FindAsync(request.id);

        if (Doctor == null)
            return BadRequest<List<GetSubjectDto>>();

        var DoctorSubjects = Doctor.Subjects.ToList();

        if (DoctorSubjects.Count == 0 || DoctorSubjects is null)
            return NotFouned<List<GetSubjectDto>>("There is no subjects have been attached to doctor yet");

        var SubjectsDtos = mapper.Map<List<GetSubjectDto>>(DoctorSubjects);

        return Success(SubjectsDtos);
    }
}
