namespace UniversityProject.Core.CQSR.Handlers.DoctorHandlers.Queries;

public class GetDoctorCoursesHandler(IDoctorRepository doctorRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetDoctorCourses, Response<List<GetCourseDto>>>
{
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


