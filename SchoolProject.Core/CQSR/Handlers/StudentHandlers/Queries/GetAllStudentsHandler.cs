namespace UniversityProject.Core.CQSR.Handlers.StudentHandlers.Queries;

public class GetAllStudentsHandler(IStudentService studentService,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetAllStudents, Response<List<GetStudentDto>>>
{
    public async Task<Response<List<GetStudentDto>>> Handle(GetAllStudents request, CancellationToken cancellationToken)
    {
        var students = await studentService.GetAll();

        if (students is null || students.Count == 0)
            return NotFouned<List<GetStudentDto>>();

        var studentsDtos = mapper.Map<List<GetStudentDto>>(students);

        return Success(studentsDtos);
    }

}
