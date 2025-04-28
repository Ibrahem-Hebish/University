
namespace UniversityProject.Core.CQSR.Queries.Teaching_Assistants_Quiries;

public record GetAllTeachingAssistants() : IRequest<Response<List<GetTeachingAssistantDto>>> { }
