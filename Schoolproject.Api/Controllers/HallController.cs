using UniversityProject.Core.CQSR.Queries.HallQueries;

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
}
