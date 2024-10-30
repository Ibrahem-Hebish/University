using UniversityProject.Core.CQSR.Queries.CourseQueries;

namespace UniversityProject.Core.CQSR.Handlers.CourseHandler;


public class Quiries(
    ICourseRepository courseRepository,
    IDoctorRepository doctorRepository,

    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetCourseById, Response<GetCourseDto>>,
    IRequestHandler<GetAllCourses, Response<List<GetCourseDto>>>,
    IRequestHandler<GetAllCoursesInASpecificTerm, Response<List<GetCourseDto>>>,
    IRequestHandler<GetCourseDoctor, Response<GetDoctorDto>>

{
    public async Task<Response<GetCourseDto>> Handle(GetCourseById request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return BadRequest<GetCourseDto>("Id must be grater than 0");

        var Course = await courseRepository.FindAsync(request.Id);

        if (Course is null)
            return NotFouned<GetCourseDto>("There is no course with this id");

        var CourseDto = mapper.Map<GetCourseDto>(Course);

        return Success(CourseDto);
    }

    public async Task<Response<List<GetCourseDto>>> Handle(GetAllCourses request, CancellationToken cancellationToken)
    {
        var Courses = await courseRepository.GetAllAsync();

        if (Courses is null || Courses.Count == 0)
            return NotFouned<List<GetCourseDto>>();

        var CoursesDto = mapper.Map<List<GetCourseDto>>(Courses);

        return Success(CoursesDto);
    }

    public async Task<Response<List<GetCourseDto>>> Handle(GetAllCoursesInASpecificTerm request, CancellationToken cancellationToken)
    {
        if (request.Level < 1 || request.Level > 4)
            return BadRequest<List<GetCourseDto>>("Level must be from 1 to 4");

        if (request.Term < 1 || request.Term > 2)
            return BadRequest<List<GetCourseDto>>("Term must be 1 or 2");

        var Courses = await courseRepository.GetAllWhere(s =>
                                 s.Level == request.Level && s.Term == request.Term);

        if (Courses is null || Courses.Count == 0)
            return NotFouned<List<GetCourseDto>>("There is no sections");

        var CoursesDto = mapper.Map<List<GetCourseDto>>(Courses);

        return Success(CoursesDto);

    }

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