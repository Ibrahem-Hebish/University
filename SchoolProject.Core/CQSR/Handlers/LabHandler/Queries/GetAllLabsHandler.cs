using UniversityProject.Core.CQSR.Queries.LabQueries;
using UniversityProject.Core.Dtos.LabDtos;

namespace UniversityProject.Core.CQSR.Handlers.LabHandler.Queries;

public class GetAllLabsHandler(ILabRepository labRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetAllLabs, Response<List<GetLab>>>
{
    public async Task<Response<List<GetLab>>> Handle(GetAllLabs request, CancellationToken cancellationToken)
    {
        var labs = await labRepository.GetAllAsync();

        if (!labs.Any())
            return NotFouned<List<GetLab>>("There are no labs in the system");

        var labsDto = mapper.Map<List<GetLab>>(labs.ToList());


        return Success(labsDto);
    }

}


