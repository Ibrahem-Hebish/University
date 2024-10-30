namespace UniversityProject.Core.CQSR.Handlers.DoctorHandlers;

public class QueriesHandler(IDoctorRepository doctorRepository, IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetDoctor, Response<GetDoctorDto>>,
    IRequestHandler<GetAllDoctors, Response<List<GetDoctorDto>>>,
    IRequestHandler<GetDoctorCourses, Response<List<GetCourseDto>>>
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

    public async Task<Response<List<GetCourseDto>>> Handle(GetDoctorCourses request, CancellationToken cancellationToken)
    {
        if (request.id <= 0)
            return BadRequest<List<GetCourseDto>>("Id must be greater than 0");

        var Doctor = await doctorRepository.FindAsync(request.id);

        if (Doctor == null)
            return BadRequest<List<GetCourseDto>>();

        var DoctorCourses = Doctor.Courses.ToList();

        if (DoctorCourses.Count == 0 || DoctorCourses is null)
            return NotFouned<List<GetCourseDto>>("There is no Courses have been attached to doctor yet");

        var CoursesDtos = mapper.Map<List<GetCourseDto>>(DoctorCourses);

        return Success(CoursesDtos);
    }
}
