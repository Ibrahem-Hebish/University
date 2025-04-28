namespace UniversityProject.Core.CQSR.Handlers.StudentHandlers.Queries;

public class GroupStudentsByDepHandler(IStudentService studentService,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GroupStudentsByDep, Response<List<GetStudentDto>>>
{
    public async Task<Response<List<GetStudentDto>>> Handle(
        GroupStudentsByDep request,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return BadRequest<List<GetStudentDto>>();

        var Student = await studentService.GroupStudentsByDepartment(request.Name);

        if (Student.Count == 0) return NotFouned<List<GetStudentDto>>();

        List<GetStudentDto> studentDtos = mapper.Map<List<GetStudentDto>>(Student);

        return Success(studentDtos);
    }
}


