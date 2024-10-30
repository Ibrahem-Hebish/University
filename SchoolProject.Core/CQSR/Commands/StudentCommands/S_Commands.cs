namespace UniversityProject.Core.CQSR.Commands.StudentCommands;

public record DeleteStudennt(
    int Id)
    : IRequest<Response<string>>
{ }

public class AddStudennt
    : AddStudentDto, IRequest<Response<string>>
{ }

public class UpdateStudent
    : UpdateStudentDto, IRequest<Response<GetStudentDto>>
{ }
