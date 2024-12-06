using UniversityProject.Core.CQSR.Queries.HallQueries;
using UniversityProject.Core.Dtos.HallDtos;

namespace UniversityProject.Core.CQSR.Handlers.HallHandler;

public class Queries(
    IHallRepository hallRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetHallById, Response<GetHall>>,
    IRequestHandler<GetAllHalls, Response<List<GetHall>>>
{
    public async Task<Response<GetHall>> Handle(GetHallById request, CancellationToken cancellationToken)
    {
        if (String.IsNullOrWhiteSpace(request.Name))
            return BadRequest<GetHall>("Name is required");

        var hall = await hallRepository.FindByNameAsync(request.Name);

        if (hall is null)
            return NotFouned<GetHall>("There is no hall with this name");

        var hallDto = mapper.Map<GetHall>(hall);

        return Success(hallDto);
    }

    public async Task<Response<List<GetHall>>> Handle(GetAllHalls request, CancellationToken cancellationToken)
    {
        var halls = await hallRepository.GetAllAsync();

        if (halls.Count == 0)
            return NotFouned<List<GetHall>>("There are no halls in the system");

        var hallsDto = mapper.Map<List<GetHall>>(halls.ToList());

        return Success(hallsDto);
    }
}
