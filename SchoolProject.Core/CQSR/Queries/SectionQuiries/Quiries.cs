using UniversityProject.Core.Dtos.SectionDtos;

namespace UniversityProject.Core.CQSR.Queries.SectionQuiries;

public record GetSectionById(int Id) : IRequest<Response<GetSectionDto>> { }
public record GetAllSections : IRequest<Response<List<GetSectionDto>>> { }
public record GetAllSectionsInASpecificTerm(int Level, int Term) : IRequest<Response<List<GetSectionDto>>> { }
public record GetSectionTeachingAssistant(int Id) : IRequest<Response<GetTeachingAssistantDto>> { }

