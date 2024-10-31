namespace Universityproject.Api.Controllers;

public class UserController(
    IMediator mediator)
    : AppController
{
    [HttpGet]
    [Route(Router.UserRouter.GetById)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetById(
        int id)
    {
        var result = await mediator.Send(new GetUserById(id));

        return NewRsponse(result);
    }

    [HttpGet]
    [Route(Router.UserRouter.GetUsers)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Authorize]
    public async Task<ActionResult> Get()
    {
        var result = await mediator.Send(new GetUsers());

        return NewRsponse(result);
    }

    [HttpPost]
    [Route(Router.UserRouter.AddNewUser)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> Create(
        AddNewUser Command)
    {
        var result = await mediator.Send(Command);

        return NewRsponse(result);
    }

    [HttpPost]
    [Route(Router.UserRouter.AddRoleToUser)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> AddRoleToUser(
        AddRoleToUser command)
    {
        var result = await mediator.Send(command);

        return NewRsponse(result);
    }
}