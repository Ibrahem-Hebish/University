namespace UniversityProject.Core.CQSR.Commands.Teaching_Assistants_Commands;

public record AttachSectionToTeachingAssistant(int Id, int SectionId) : IRequest<Response<string>> { }
