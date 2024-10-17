namespace Schoolproject.Api.Controllers;

public class PasswordManagerController(
    IMediator mediator)
    : AppController(mediator)
{
    [HttpPost]
    [Route(Router.UserRouter.ChangePassword)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Change(
        ChangePassword command)
    {
        var isCreated = await mediator.Send(command);

        return NewRsponse(isCreated);
    }

    [HttpPost(Router.UserRouter.SendCodeToResetPassword)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> SendCodeToReset(
        SendEmilForResetPassword command)
    {
        var isCreated = await mediator.Send(command);

        return NewRsponse(isCreated);
    }

    [HttpPost(Router.UserRouter.ConfirmCodeForResetPassword)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> ConfirmCodeForReset(
        ConfirmCodeToResetPassword command)
    {
        var isCreated = await mediator.Send(command);

        return NewRsponse(isCreated);
    }

    [HttpPost(Router.UserRouter.ResetPassword)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Reset(
        ResetPassword command)
    {
        var isCreated = await mediator.Send(command);

        return NewRsponse(isCreated);
    }
}