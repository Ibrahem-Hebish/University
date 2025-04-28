namespace UniversityProject.Core.CQSR.Handlers.StudentHandlers.Queries;

public class GroupStudentsByCourseHandler(IStudentService studentService,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GroupStudentsByCourse, Response<List<GetStudentDto>>>
{
    public async Task<Response<List<GetStudentDto>>> Handle(
        GroupStudentsByCourse request,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return BadRequest<List<GetStudentDto>>();

        var Student = await studentService.GroupStudentsByCourse(request.Name);

        if (Student.Count == 0) return NotFouned<List<GetStudentDto>>();

        List<GetStudentDto> studentDtos = mapper.Map<List<GetStudentDto>>(Student);

        return Success(studentDtos);
    }
}


