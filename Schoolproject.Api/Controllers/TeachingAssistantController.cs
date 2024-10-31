using UniversityProject.Core.CQSR.Commands.Teaching_Assistants_Commands;

namespace Universityproject.Api.Controllers;

[ProducesResponseType(StatusCodes.Status404NotFound)]
public class TeachingAssistantController(IMediator mediator) : AppController
{

    [HttpGet]
    [Route(Router.TeachingAssistant.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetTeachingAssistantDto>> Get(int id)
    {
        var TeachingAssistant = await mediator.Send(new GetTeachingAssistantByID(id));

        return NewRsponse(TeachingAssistant);
    }

    [HttpGet]
    [Route(Router.TeachingAssistant.GetAll)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetTeachingAssistantDto>> GetAll()
    {
        var TeachingAssistant = await mediator.Send(new GetAllTeachingAssistants());

        return NewRsponse(TeachingAssistant);
    }

    [HttpPost]
    [Route(Router.TeachingAssistant.AddTeachingAssistant)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<GetCourseDto>>> Create(AddTeachingAssistant Command)
    {
        var result = await mediator.Send(Command);

        return NewRsponse(result);
    }
    [HttpPost]
    [Route(Router.TeachingAssistant.AttachSectionToTeachingAssistant)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<GetCourseDto>>> AttachSectionTo(
        AttachSectionToTeachingAssistant Command)
    {
        var result = await mediator.Send(Command);

        return NewRsponse(result);
    }

    [HttpPut]
    [Route(Router.TeachingAssistant.ChangeOffice)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetTeachingAssistantDto>> ChangeOffice(
        ChangeTeachingAssistantOffice Command)
    {
        var TeachingAssistant = await mediator.Send(Command);

        return NewRsponse(TeachingAssistant);
    }

    [HttpDelete]
    [Route(Router.TeachingAssistant.Delete)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetTeachingAssistantDto>> Delete(int id)
    {
        var TeachingAssistant = await mediator.Send(new DeleteTeachingAssistant(id));

        return NewRsponse(TeachingAssistant);
    }
}
