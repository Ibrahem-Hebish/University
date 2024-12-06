using UniversityProject.Core.Dtos.LabDtos;

namespace UniversityProject.Core.CQSR.Queries.LabQueries;

public record GetLabById(string Name) : IRequest<Response<GetLab>> { }
public record GetAllLabs() : IRequest<Response<List<GetLab>>> { }
