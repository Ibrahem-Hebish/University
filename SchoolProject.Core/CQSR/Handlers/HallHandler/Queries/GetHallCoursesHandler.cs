using UniversityProject.Core.CQSR.Queries.HallQueries;

namespace UniversityProject.Core.CQSR.Handlers.HallHandler.Queries;

public class GetHallCoursesHandler(IHallRepository hallRepository,
    ICourseRepository courseRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetHallCourses, Response<List<GetCourseDto>>>
{
    public async Task<Response<List<GetCourseDto>>> Handle(GetHallCourses request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return BadRequest<List<GetCourseDto>>("Name is required");

        var hall = await hallRepository.FindByNameAsync(request.Name);

        if (hall is null)
            return NotFouned<List<GetCourseDto>>("There is no hall with this name");

        var courses = await courseRepository.GetAllWhere(c =>
        c.HallName!.ToLower() == request.Name.ToLower());

        if (courses is null || !courses.Any())
            return NotFouned<List<GetCourseDto>>("There is no courses in this hall");

        var coursesDtos = mapper.Map<List<GetCourseDto>>(courses.ToList());

        return Success(coursesDtos);
    }

}



