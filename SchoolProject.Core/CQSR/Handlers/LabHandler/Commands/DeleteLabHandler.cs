using UniversityProject.Core.CQSR.Commands.LabCommands;

namespace UniversityProject.Core.CQSR.Handlers.LabHandler.Commands;

public class DeleteLabHandler(ILabRepository labRepository,
    ISectionRepository sectionRepository) :
    ResponseHandler,
    IRequestHandler<DeleteLab, Response<string>>
{
    public async Task<Response<string>> Handle(DeleteLab request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return BadRequest<string>("Name is required");

        Lab lab = await labRepository.FindByNameAsync(request.Name);

        if (lab == null)
            return NotFouned<string>("There is no lab with this name");

        var sections = await sectionRepository.GetAllWhere(s => s.LabName == request.Name);
        if (sections.Any())
        {
            foreach (var section in sections)
            {
                section.LabName = null;
            }
        }

        await labRepository.DeleteAsync(lab, request.Name);

        return Deleted<string>("Lab is deleted successfully");

    }

}


