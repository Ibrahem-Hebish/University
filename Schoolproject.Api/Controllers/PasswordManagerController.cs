namespace Universityproject.Api.Controllers;

public class PasswordManagerController(
    IMediator mediator)
    : AppController
{
    [HttpPost]
    [Route(Router.UserRouter.ChangePassword)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Change(
        ChangePassword command)
    {
        var result = await mediator.Send(command);

        return NewRsponse(result);
    }

    [HttpPost(Router.UserRouter.SendCodeToResetPassword)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> SendCodeToReset(
        SendEmilForResetPassword command)
    {
        var result = await mediator.Send(command);

        return NewRsponse(result);
    }

    [HttpPost(Router.UserRouter.ConfirmCodeForResetPassword)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> ConfirmCodeForReset(
        ConfirmCodeToResetPassword command)
    {
        var result = await mediator.Send(command);

        return NewRsponse(result);
    }

    [HttpPost(Router.UserRouter.ResetPassword)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Reset(
        ResetPassword command)
    {
        var result = await mediator.Send(command);

        return NewRsponse(result);
    }
}