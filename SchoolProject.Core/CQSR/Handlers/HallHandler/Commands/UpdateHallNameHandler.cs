using UniversityProject.Core.CQSR.Commands.HallCommands;
using UniversityProject.Core.Dtos.HallDtos;

namespace UniversityProject.Core.CQSR.Handlers.HallHandler.Commands;

public class UpdateHallNameHandler(IHallRepository hallRepository,
    ICourseRepository courseRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<UpdateHallName, Response<GetHall>>
{
    public async Task<Response<GetHall>> Handle(UpdateHallName request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.CurrentName))
            return BadRequest<GetHall>("Current Name is required");

        if (string.IsNullOrWhiteSpace(request.NewName))
            return BadRequest<GetHall>("New Name is required");

        var labs = await hallRepository.GetAllAsync();

        foreach (var exsistedLab in labs)
        {
            if (exsistedLab.Name == request.NewName)
                return BadRequest<GetHall>("There is hall with this name,please change the name");
        }

        var hall = await hallRepository.FindByNameAsync(request.CurrentName);

        if (hall is null)
            return NotFouned<GetHall>("There is no lab with this name");

        var courses = await courseRepository.GetAllWhere(s => s.HallName == request.CurrentName);
        if (courses.Any())
        {
            foreach (var course in courses)
            {
                course.HallName = request.NewName;
            }
        }

        hall.Name = request.NewName;

        var result = await hallRepository.UpdateAsync(hall, request.CurrentName);

        var officeDto = mapper.Map<GetHall>(result);

        return Success(officeDto);
    }

}

