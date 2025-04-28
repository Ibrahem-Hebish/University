using UniversityProject.Core.CQSR.Queries.CourseQueries;

namespace UniversityProject.Core.CQSR.Handlers.CourseHandler.Queries;

public class GetCourseDoctorHandler(
    IDoctorRepository doctorRepository,
    ICourseRepository courseRepository,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetCourseDoctor, Response<GetDoctorDto>>
{
    public async Task<Response<GetDoctorDto>> Handle(GetCourseDoctor request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return BadRequest<GetDoctorDto>("Id must be grater than 0");

        var Course = await courseRepository.FindAsync(request.Id);

        if (Course is null)
            return NotFouned<GetDoctorDto>("There is no Course with this id");

        if (Course.DoctorId is null)
            return BadRequest<GetDoctorDto>("There is no doctor attached to this section");

        var Doctor = await doctorRepository.FindAsync((int)Course.DoctorId);

        var DoctorDto = mapper.Map<GetDoctorDto>(Doctor);

        return Success(DoctorDto);
    }

}


