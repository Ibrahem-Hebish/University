using UniversityProject.Core.CQSR.Commands.HallCommands;
using UniversityProject.Core.CQSR.Queries.HallQueries;
using UniversityProject.Core.Dtos.HallDtos;

namespace Universityproject.Api.Controllers;

public class HallController(IMediator mediator) : AppController
{
    [HttpGet]
    [Route(Router.Hall.GetById)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Hall>> GetById(string Name)
    {
        var result = await mediator.Send(new GetHallById(Name));

        return NewRsponse(result);
    }

    [HttpGet]
    [Route(Router.Hall.GetAll)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Hall>> GetAll()
    {
        var result = await mediator.Send(new GetAllHalls());

        return NewRsponse(result);
    }
    [HttpPut]
    [Route(Router.Hall.ChangeName)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetHall>> ChangeName(UpdateHallName command)
    {
        var result = await mediator.Send(command);

        return NewRsponse(result);
    }


    [HttpDelete]
    [Route(Router.Hall.Delete)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<string>> Delete(string Name)
    {
        var result = await mediator.Send(new DeleteHall(Name));

        return NewRsponse(result);
    }
}
