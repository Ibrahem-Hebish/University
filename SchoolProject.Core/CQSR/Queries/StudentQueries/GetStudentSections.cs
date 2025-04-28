using UniversityProject.Core.Dtos.SectionDtos;

namespace UniversityProject.Core.CQSR.Queries.StudentQueries;

public record GetStudentSections(int Id) : IRequest<Response<List<GetSectionDto>>> { }
