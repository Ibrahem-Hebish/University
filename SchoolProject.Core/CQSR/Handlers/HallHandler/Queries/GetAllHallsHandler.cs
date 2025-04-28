using UniversityProject.Core.CQSR.Queries.HallQueries;
using UniversityProject.Core.Dtos.HallDtos;

namespace UniversityProject.Core.CQSR.Handlers.HallHandler.Queries;

public class GetAllHallsHandler(IHallRepository hallRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetAllHalls, Response<List<GetHall>>>
{
    public async Task<Response<List<GetHall>>> Handle(GetAllHalls request, CancellationToken cancellationToken)
    {
        var halls = await hallRepository.GetAllAsync();

        if (!halls.Any())
            return NotFouned<List<GetHall>>("There are no halls in the system");

        var hallsDto = mapper.Map<List<GetHall>>(halls.ToList());

        return Success(hallsDto);
    }

}



