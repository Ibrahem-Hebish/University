using UniversityProject.Core.CQSR.Commands.LabCommands;
using UniversityProject.Core.Dtos.LabDtos;

namespace UniversityProject.Core.CQSR.Handlers.LabHandler.Commands;

public class UpdateLabNameHandler(ILabRepository labRepository,
    ISectionRepository sectionRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<UpdateLabName, Response<GetLab>>
{
    public async Task<Response<GetLab>> Handle(UpdateLabName request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.CurrentName))
            return BadRequest<GetLab>("Current Name is required");

        if (string.IsNullOrWhiteSpace(request.NewName))
            return BadRequest<GetLab>("New Name is required");

        var sections = await sectionRepository.GetAllWhere(s => s.LabName == request.CurrentName);
        if (sections.Any())
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

