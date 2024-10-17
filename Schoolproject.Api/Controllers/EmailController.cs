namespace Schoolproject.Api.Controllers;

public class EmailController(
    IMediator mediator)
    : AppController(mediator)
{

    [HttpPost]
    [Route(Router.EmailRouter.SendEmail)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Send(
        SendEmailCommand command)
    {
        var result = await mediator.Send(command);

        return NewRsponse(result);
    }
}
