namespace UniversityProject.Core.CQSR.Commands.StudentCommands;

public class UpdateStudent
    : UpdateStudentDto, IRequest<Response<GetStudentDto>>
{ }
