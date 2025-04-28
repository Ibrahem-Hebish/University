using UniversityProject.Core.CQSR.Queries.CourseQueries;

namespace UniversityProject.Core.CQSR.Handlers.CourseHandler.Queries;

public class GetAllCoursesInASpecificTermHandler(
    ICourseRepository courseRepository, IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetAllCoursesInASpecificTerm, Response<List<GetCourseDto>>>
{
    public async Task<Response<List<GetCourseDto>>> Handle(GetAllCoursesInASpecificTerm request, CancellationToken cancellationToken)
    {
        if (request.Level < 1 || request.Level > 4)
            return BadRequest<List<GetCourseDto>>("Level must be from 1 to 4");

        if (request.Term < 1 || request.Term > 2)
            return BadRequest<List<GetCourseDto>>("Term must be 1 or 2");

        var Courses = await courseRepository.GetAllWhere(s =>
                                 s.Level == request.Level && s.Term == request.Term);

        if (Courses is null || !Courses.Any())
            return NotFouned<List<GetCourseDto>>("There is no sections");

        var CoursesDto = mapper.Map<List<GetCourseDto>>(Courses);

        return Success(CoursesDto);

    }

}


