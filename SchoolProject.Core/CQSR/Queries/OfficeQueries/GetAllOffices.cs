using UniversityProject.Core.Dtos.OfficeDtos;

namespace UniversityProject.Core.CQSR.Queries.OfficeQueries;

public record GetAllOffices() : IRequest<Response<List<GetOffice>>> { }
