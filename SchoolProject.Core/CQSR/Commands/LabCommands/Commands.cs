using UniversityProject.Core.Dtos.LabDtos;

namespace UniversityProject.Core.CQSR.Commands.LabCommands;

public record DeleteLab(string Name) : IRequest<Response<string>> { }
public record UpdateLabName(string CurrentName, string NewName) : IRequest<Response<GetLab>> { }
