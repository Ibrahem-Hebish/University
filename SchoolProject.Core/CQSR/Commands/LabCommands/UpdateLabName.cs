using UniversityProject.Core.Dtos.LabDtos;

namespace UniversityProject.Core.CQSR.Commands.LabCommands;
public record UpdateLabName(string CurrentName, string NewName) : IRequest<Response<GetLab>> { }
