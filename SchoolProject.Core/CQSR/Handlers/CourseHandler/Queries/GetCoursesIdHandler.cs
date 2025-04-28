using UniversityProject.Core.CQSR.Queries.CourseQueries;

namespace UniversityProject.Core.CQSR.Handlers.CourseHandler.Queries;

public class GetCoursesIdHandler(
    ICourseRepository courseRepository, IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetAllCourses, Response<List<GetCourseDto>>>
{
    public async Task<Response<List<GetCourseDto>>> Handle(GetAllCourses request, CancellationToken cancellationToken)
    {
        var Courses = await courseRepository.GetAllAsync();

        if (Courses is null || !Courses.Any())
            return NotFouned<List<GetCourseDto>>();

        var CoursesDto = mapper.Map<List<GetCourseDto>>(Courses);

        return Success(CoursesDto);
    }

}


