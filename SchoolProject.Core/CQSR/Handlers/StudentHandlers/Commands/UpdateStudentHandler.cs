namespace UniversityProject.Core.CQSR.Handlers.StudentHandlers.Commands;

public class UpdateStudentHandler(IStudentService studentService,
    IStudentRepository studentRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<UpdateStudent, Response<GetStudentDto>>
{
    public async Task<Response<GetStudentDto>> Handle(
        UpdateStudent request,
        CancellationToken cancellationToken)
    {
        var ExsistingStudent = await studentService.GetStudentById(request.Id);

        if (ExsistingStudent == null)
            return BadRequest<GetStudentDto>("Student is not found");

        var student = mapper.Map<Student>(request);

        ExsistingStudent.Address = student.Address;
        ExsistingStudent.Name = student.Name;
        ExsistingStudent.Phone = student.Phone;

        await studentRepository.UpdateAsync(ExsistingStudent, request.Id);

        var StudentDto = mapper.Map<GetStudentDto>(ExsistingStudent);

        return Success(StudentDto, "Updated Successfully");

    }
}



