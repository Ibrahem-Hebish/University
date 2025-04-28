namespace UniversityProject.Core.CQSR.Handlers.StudentHandlers.Commands;

public class DeleteStudenntHandler(IStudentService studentService,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<DeleteStudennt, Response<string>>
{
    public async Task<Response<string>> Handle(
        DeleteStudennt request,
        CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return BadRequest<string>("id must be grater than 0");

        var student = await studentService.DeleteStudent(request.Id);

        if (student == false)
            return NotFouned<string>();
        return Deleted<string>();

    }
}



