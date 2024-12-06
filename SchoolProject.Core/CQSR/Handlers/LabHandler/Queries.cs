using UniversityProject.Core.CQSR.Queries.LabQueries;
using UniversityProject.Core.Dtos.LabDtos;

namespace UniversityProject.Core.CQSR.Handlers.LabHandler;

public class Queries(
    ILabRepository labRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetLabById, Response<GetLab>>,
    IRequestHandler<GetAllLabs, Response<List<GetLab>>>
{
    public async Task<Response<GetLab>> Handle(GetLabById request, CancellationToken cancellationToken)
    {
        if (String.IsNullOrWhiteSpace(request.Name))
            return BadRequest<GetLab>("Name is required");

        var lab = await labRepository.FindByNameAsync(request.Name);

        if (lab is null)
            return NotFouned<GetLab>("There is no hall with this name");

        var labDto = mapper.Map<GetLab>(lab);

        return Success(labDto);
    }

    public async Task<Response<List<GetLab>>> Handle(GetAllLabs request, CancellationToken cancellationToken)
    {
        var labs = await labRepository.GetAllAsync();

        if (labs.Count == 0)
            return NotFouned<List<GetLab>>("There are no labs in the system");

        var labsDto = mapper.Map<List<GetLab>>(labs.ToList());


        return Success(labsDto);
    }
}
