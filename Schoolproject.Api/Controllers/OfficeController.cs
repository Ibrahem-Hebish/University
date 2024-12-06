using UniversityProject.Core.CQSR.Commands.OfficeCommands;
using UniversityProject.Core.CQSR.Queries.OfficeQueries;

namespace Universityproject.Api.Controllers;


public class OfficeController(IMediator mediator) : AppController
{
    [HttpGet]
    [Route(Router.Office.GetById)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Hall>> GetById(string Name)
    {
        var result = await mediator.Send(new GetOfficeById(Name));

        return NewRsponse(result);
    }

    [HttpGet]
    [Route(Router.Office.GetAll)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<Office>>> GetAll()
    {
        var result = await mediator.Send(new GetAllOffices());

        return NewRsponse(result);
    }

    [HttpGet]
    [Route(Router.Office.GetStaff)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<Office>>> GetStaff(string Name)
    {
        var result = await mediator.Send(new GetStaffInOffice(Name));

        return NewRsponse(result);
    }


    [HttpDelete]
    [Route(Router.Office.Delete)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<string>> Delete(string Name)
    {
        var result = await mediator.Send(new DeleteOffice(Name));

        return NewRsponse(result);
    }
}