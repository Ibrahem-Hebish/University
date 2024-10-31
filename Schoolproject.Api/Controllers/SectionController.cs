using UniversityProject.Core.CQSR.Queries.SectionQuiries;
using UniversityProject.Core.Dtos.SectionDtos;

namespace Universityproject.Api.Controllers;


public class SectionController(IMediator mediator) : AppController
{
    [HttpGet]
    [Route(Router.Section.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetSectionDto>> Get(int id)
    {
        var result = await mediator.Send(new GetSectionById(id));

        return NewRsponse(result);
    }

    [HttpGet]
    [Route(Router.Section.GetAll)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<GetSectionDto>>> GetAll()
    {
        var result = await mediator.Send(new GetAllSections());

        return NewRsponse(result);
    }

    [HttpGet]
    [Route(Router.Section.GetAllInSpecificTerm)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<GetSectionDto>>> GetAllInSpecificTerm(int Level, int Term)
    {
        var result = await mediator.Send(new GetAllSectionsInASpecificTerm(Level, Term));

        return NewRsponse(result);
    }

    [HttpGet]
    [Route(Router.Section.GetSectionTeachingAssistant)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetTeachingAssistantDto>> GetSectionTeachingAssistant(int id)
    {
        var result = await mediator.Send(new GetSectionTeachingAssistant(id));

        return NewRsponse(result);
    }

}
