using UniversityProject.Core.CQSR.Commands.LabCommands;
using UniversityProject.Core.Dtos.LabDtos;

namespace UniversityProject.Core.CQSR.Handlers.LabHandler;

public class Commands(
    ILabRepository labRepository,
    ISectionRepository sectionRepository,
    IMapper mapper) :
    ResponseHandler,

    IRequestHandler<DeleteLab, Response<string>>,
    IRequestHandler<UpdateLabName, Response<GetLab>>
{
    public async Task<Response<string>> Handle(DeleteLab request, CancellationToken cancellationToken)
    {
        if (String.IsNullOrWhiteSpace(request.Name))
            return BadRequest<string>("Name is required");

        Lab lab = await labRepository.FindByNameAsync(request.Name);

        if (lab == null)
            return NotFouned<string>("There is no lab with this name");

        var sections = await sectionRepository.GetAllWhere(s => s.LabName == request.Name);
        if (sections.Count != 0)
        {
            foreach (var section in sections)
            {
                section.LabName = null;
            }
        }

        await labRepository.DeleteAsync(lab, request.Name);

        return Deleted<string>("Lab is deleted successfully");

    }

    public async Task<Response<GetLab>> Handle(UpdateLabName request, CancellationToken cancellationToken)
    {
        if (String.IsNullOrWhiteSpace(request.CurrentName))
            return BadRequest<GetLab>("Current Name is required");

        if (String.IsNullOrWhiteSpace(request.NewName))
            return BadRequest<GetLab>("New Name is required");

        var sections = await sectionRepository.GetAllWhere(s => s.LabName == request.CurrentName);
        if (sections.Count != 0)
        {
            foreach (var section in sections)
            {
                section.LabName = request.NewName;
            }
        }

        var labs = await labRepository.GetAllAsync();

        foreach (var exsistedLab in labs)
        {
            if (exsistedLab.Name == request.NewName)
                return BadRequest<GetLab>("There is lab with this name,please change the name");
        }

        var lab = await labRepository.FindByNameAsync(request.CurrentName);

        if (lab is null)
            return NotFouned<GetLab>("There is no lab with this name");

        lab.Name = request.NewName;

        var result = await labRepository.UpdateAsync(lab, request.CurrentName);

        var officeDto = mapper.Map<GetLab>(result);

        return Success(officeDto);
    }
}
