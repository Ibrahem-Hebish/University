namespace Universityproject.Api.Controllers;

public class AuthonticationController(
    IMediator mediator)
    : AppController
{
    [HttpPost]
    [Route(Router.AuthonticationRouter.SignIn)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> SignIn(
        SignInCommand signIn)
    {
        var result = await mediator.Send(signIn);

        return NewRsponse(result);
    }

    [HttpPost]
    [Route(Router.AuthonticationRouter.RefreshToken)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> RefreshToken(
        RefreshTokenCommand Command)
    {
        var result = await mediator.Send(Command);

        return NewRsponse(result);
    }

    [HttpPost]
    [Route(Router.AuthonticationRouter.VakidateToken)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> ValidateToken(
        ValidateTokenCommand Command)
    {

        var result = await mediator.Send(Command);

        return NewRsponse(result);
    }

    [HttpGet]
    [Route(Router.AuthonticationRouter.ConfirmEmail)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> ConfirmEmail()
    {
        var result = await mediator.Send(new ConfirmEmailCommand());

        return NewRsponse(result);
    }
}
