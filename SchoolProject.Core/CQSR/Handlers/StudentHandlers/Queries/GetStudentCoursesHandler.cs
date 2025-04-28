namespace UniversityProject.Core.CQSR.Handlers.StudentHandlers.Queries;

public class GetStudentCoursesHandler(IStudentRepository studentRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetStudentCourses, Response<List<GetCourseDto>>>
{
    public async Task<Response<List<GetCourseDto>>> Handle(GetStudentCourses request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return BadRequest<List<GetCourseDto>>("Id must be grater than 0");

        var student = await studentRepository.FindAsync(request.Id);

        if (student is null)
            return BadRequest<List<GetCourseDto>>("There is no student with this id");

        var studentCourses = await studentRepository.GetStudentCourses(student);

        if (studentCourses is null)
            return NotFouned<List<GetCourseDto>>("There has not been courses attached to this student yet");

        var coursesDto = mapper.Map<List<GetCourseDto>>(studentCourses);

        return Success(coursesDto);
    }

}
