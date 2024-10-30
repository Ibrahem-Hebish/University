
namespace UniversityProject.Core.CQSR.Queries.Teaching_Assistants_Quiries;

public record GetTeachingAssistantByID(int Id) : IRequest<Response<GetTeachingAssistantDto>> { }

public record GetAllTeachingAssistants() : IRequest<Response<List<GetTeachingAssistantDto>>> { }
