using UniversityProject.Core.CQSR.Queries.LabQueries;

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
}
