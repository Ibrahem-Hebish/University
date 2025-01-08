using UniversityProject.Core.Dtos.OfficeDtos;

namespace UniversityProject.Core.CQSR.Commands.OfficeCommands;

public record DeleteOffice(string Name) : IRequest<Response<string>> { }
public record UpdateOfficeName(string CurrentName, string NewName) : IRequest<Response<GetOffice>> { }

