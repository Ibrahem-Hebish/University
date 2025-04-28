using UniversityProject.Core.CQSR.Commands.HallCommands;

namespace UniversityProject.Core.CQSR.Handlers.HallHandler.Commands;

public class DeleteHallHandler(IHallRepository hallRepository,
    ICourseRepository courseRepository) :
    ResponseHandler,
    IRequestHandler<DeleteHall, Response<string>>
{
    public async Task<Response<string>> Handle(DeleteHall request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return BadRequest<string>("Name is required");

        Hall hall = await hallRepository.FindByNameAsync(request.Name);

        if (hall == null)
            return NotFouned<string>("There is no hall with this name");

        var courses = await courseRepository.GetAllWhere(s => s.HallName == request.Name);
        if (courses.Any())
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



