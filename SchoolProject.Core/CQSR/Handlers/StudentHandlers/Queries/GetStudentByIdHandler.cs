namespace UniversityProject.Core.CQSR.Handlers.StudentHandlers.Queries;

public class GetStudentByIdHandler(IStudentService studentService,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetStudentById, Response<GetStudentDto>>
{
    public async Task<Response<GetStudentDto>> Handle(
        GetStudentById request,
        CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return BadRequest<GetStudentDto>("Id must be grater than 0");
        var student = await studentService.GetStudentById(request.Id);

        if (student is null) return NotFouned<GetStudentDto>();

        var s_dto = mapper.Map<GetStudentDto>(student);

        return Success(s_dto);
    }
}



