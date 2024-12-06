using UniversityProject.Core.Dtos.OfficeDtos;

namespace UniversityProject.Core.CQSR.Queries.OfficeQueries;

public record GetOfficeById(string Name) : IRequest<Response<GetOffice>> { }
public record GetAllOffices() : IRequest<Response<List<GetOffice>>> { }

public record GetStaffInOffice(string Name) : IRequest<Response<OfficeStaff>> { }
