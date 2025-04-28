namespace UniversityProject.Core.CQSR.Commands.Teaching_Assistants_Commands;

public record DeleteTeachingAssistant(int Id) : IRequest<Response<string>> { }
