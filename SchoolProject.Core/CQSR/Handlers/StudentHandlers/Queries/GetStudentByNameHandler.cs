namespace UniversityProject.Core.CQSR.Handlers.StudentHandlers.Queries;

public class GetStudentByNameHandler(IStudentService studentService,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetStudentByName, Response<GetStudentDto>>
{
    public async Task<Response<GetStudentDto>> Handle(
        GetStudentByName request,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return BadRequest<GetStudentDto>();

        var Student = await studentService.GetStudentByName(request.Name);

        if (Student is null) return NotFouned<GetStudentDto>();

        var s_dto = mapper.Map<GetStudentDto>(Student);

        return Success(s_dto);
    }
}


