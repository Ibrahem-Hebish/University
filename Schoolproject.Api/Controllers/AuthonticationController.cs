using SchoolProject.Infrustructure.Data;

namespace Schoolproject.Api.Controllers;

public class AuthonticationController(
    IMediator mediator, AppDbContext appdbcontext)
    : AppController(mediator)
{
    [HttpPost]
    [Route(Router.AuthonticationRouter.SignIn)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> SignIn(
        SignInCommand signIn)
    {
        var isCreated = await mediator.Send(signIn);

        return NewRsponse(isCreated);
    }

    [HttpPost]
    [Route(Router.AuthonticationRouter.RefreshToken)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> RefreshToken(
        RefreshTokenCommand Command)
    {
        var isCreated = await mediator.Send(Command);

        return NewRsponse(isCreated);
    }

    [HttpPost]
    [Route(Router.AuthonticationRouter.VakidateToken)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> ValidateToken(
        ValidateTokenCommand Command)
    {
        if (String.IsNullOrEmpty(Command.AccessToken)) return BadRequest("Input the data");

        var isCreated = await mediator.Send(Command);

        return NewRsponse(isCreated);
    }

    [HttpGet]
    [Route(Router.AuthonticationRouter.ConfirmEmail)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> ConfirmEmail(
        string code)
    {
        var isCreated = await mediator.Send(new ConfirmEmailCommand(code));

        return NewRsponse(isCreated);
    }
}
