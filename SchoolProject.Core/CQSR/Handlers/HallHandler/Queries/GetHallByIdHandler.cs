using UniversityProject.Core.CQSR.Queries.HallQueries;
using UniversityProject.Core.Dtos.HallDtos;

namespace UniversityProject.Core.CQSR.Handlers.HallHandler.Queries;

public class GetHallByIdHandler(IHallRepository hallRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetHallById, Response<GetHall>>
{
    public async Task<Response<GetHall>> Handle(GetHallById request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return BadRequest<GetHall>("Name is required");

        var hall = await hallRepository.FindByNameAsync(request.Name);

        if (hall is null)
            return NotFouned<GetHall>("There is no hall with this name");

        var hallDto = mapper.Map<GetHall>(hall);

        return Success(hallDto);
    }

}



