using UniversityProject.Core.CQSR.Queries.CourseQueries;

namespace UniversityProject.Core.CQSR.Handlers.CourseHandler.Queries;

public class GetCourseByIdHandler(
    ICourseRepository courseRepository, IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetCourseById, Response<GetCourseDto>>
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

}


