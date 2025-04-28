namespace UniversityProject.Core.CQSR.Commands.StudentCommands;

public record DeleteStudennt(
    int Id)
    : IRequest<Response<string>>
{ }
