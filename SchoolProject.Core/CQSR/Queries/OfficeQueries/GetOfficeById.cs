using UniversityProject.Core.Dtos.OfficeDtos;

namespace UniversityProject.Core.CQSR.Queries.OfficeQueries;

public record GetOfficeById(string Name) : IRequest<Response<GetOffice>> { }
