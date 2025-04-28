namespace UniversityProject.Core.CQSR.Queries.SectionQuiries;
public record GetSectionTeachingAssistant(int Id) : IRequest<Response<GetTeachingAssistantDto>> { }

