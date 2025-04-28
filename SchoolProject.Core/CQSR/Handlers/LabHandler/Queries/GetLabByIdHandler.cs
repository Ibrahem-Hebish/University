using UniversityProject.Core.CQSR.Queries.LabQueries;
using UniversityProject.Core.Dtos.LabDtos;

namespace UniversityProject.Core.CQSR.Handlers.LabHandler.Queries;

public class GetLabByIdHandler(ILabRepository labRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetLabById, Response<GetLab>>
{
    public async Task<Response<GetLab>> Handle(GetLabById request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return BadRequest<GetLab>("Name is required");

        var lab = await labRepository.FindByNameAsync(request.Name);

        if (lab is null)
            return NotFouned<GetLab>("There is no hall with this name");

        var labDto = mapper.Map<GetLab>(lab);

        return Success(labDto);
    }

}


