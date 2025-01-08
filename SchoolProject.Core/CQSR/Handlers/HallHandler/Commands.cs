using UniversityProject.Core.CQSR.Commands.HallCommands;
using UniversityProject.Core.Dtos.HallDtos;

namespace UniversityProject.Core.CQSR.Handlers.HallHandler;

public class Commands(
    IHallRepository hallRepository,
    ICourseRepository courseRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<DeleteHall, Response<string>>,
    IRequestHandler<UpdateHallName, Response<GetHall>>
{
    public async Task<Response<GetHall>> Handle(UpdateHallName request, CancellationToken cancellationToken)
    {
        if (String.IsNullOrWhiteSpace(request.CurrentName))
            return BadRequest<GetHall>("Current Name is required");

        if (String.IsNullOrWhiteSpace(request.NewName))
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
        if (courses.Count != 0)
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

    public async Task<Response<string>> Handle(DeleteHall request, CancellationToken cancellationToken)
    {
        if (String.IsNullOrWhiteSpace(request.Name))
            return BadRequest<string>("Name is required");

        Hall hall = await hallRepository.FindByNameAsync(request.Name);

        if (hall == null)
            return NotFouned<string>("There is no hall with this name");

        var courses = await courseRepository.GetAllWhere(s => s.HallName == request.Name);
        if (courses.Count != 0)
        {
            foreach (var course in courses)
            {
                course.HallName = null;
            }
        }

        await hallRepository.DeleteAsync(hall, request.Name);

        return Deleted<string>("Hall is deleted successfully");
    }
}
