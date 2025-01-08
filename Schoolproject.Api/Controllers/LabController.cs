using UniversityProject.Core.CQSR.Commands.LabCommands;
using UniversityProject.Core.CQSR.Queries.LabQueries;
using UniversityProject.Core.Dtos.LabDtos;

namespace Universityproject.Api.Controllers;


public class LabController(IMediator mediator) : AppController
{
    [HttpGet]
    [Route(Router.Lab.GetById)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Hall>> GetById(string Name)
    {
        var result = await mediator.Send(new GetLabById(Name));

        return NewRsponse(result);
    }

    [HttpGet]
    [Route(Router.Lab.GetAll)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Hall>> GetAll()
    {
        var result = await mediator.Send(new GetAllLabs());

        return NewRsponse(result);
    }
    [HttpPut]
    [Route(Router.Lab.ChangeName)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetLab>> ChangeName(UpdateLabName command)
    {
        var result = await mediator.Send(command);

        return NewRsponse(result);
    }


    [HttpDelete]
    [Route(Router.Lab.Delete)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<string>> Delete(string Name)
    {
        var result = await mediator.Send(new DeleteLab(Name));

        return NewRsponse(result);
    }
}
