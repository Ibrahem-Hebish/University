using UniversityProject.Core.Dtos.OfficeDtos;

namespace UniversityProject.Core.CQSR.Commands.OfficeCommands;
public record UpdateOfficeName(string CurrentName, string NewName) : IRequest<Response<GetOffice>> { }

