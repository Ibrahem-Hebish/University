using UniversityProject.Core.Dtos.OfficeDtos;

namespace UniversityProject.Core.CQSR.Queries.OfficeQueries;

public record GetStaffInOffice(string Name) : IRequest<Response<OfficeStaff>> { }
