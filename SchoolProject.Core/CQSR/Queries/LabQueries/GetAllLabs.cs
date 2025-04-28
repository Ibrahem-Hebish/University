using UniversityProject.Core.Dtos.LabDtos;

namespace UniversityProject.Core.CQSR.Queries.LabQueries;
public record GetAllLabs() : IRequest<Response<List<GetLab>>> { }
