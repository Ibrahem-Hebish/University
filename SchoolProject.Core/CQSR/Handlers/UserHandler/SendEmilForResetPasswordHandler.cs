namespace SchoolProject.Core.CQSR.Handlers.UserHandler;

public class SendEmilForResetPasswordHandler(
    IUserService userService)

    : ResponseHandler,
    IRequestHandler<SendEmilForResetPassword, Response<string>>,
    IRequestHandler<ConfirmCodeToResetPassword, Response<string>>,
    IRequestHandler<ResetPassword, Response<string>>
{
    public async Task<Response<string>> Handle(
        SendEmilForResetPassword request,
        CancellationToken cancellationToken)
    {
        var result = await userService.SendCodeToResetPassword(request.email);

        switch (result)
        {
            case "User Not Found": return BadRequest<string>("User Not Found");

            case "Failed sending email": return BadRequest<string>("Failed sending email");

            case "failed": return BadRequest<string>("Something went wrong");

            case "Success": return NoContent<string>("Success");

            default: return BadRequest<string>("Something went wrong");
        }
    }

    public async Task<Response<string>> Handle(
        ConfirmCodeToResetPassword request,
        CancellationToken cancellationToken)
    {
        var result = await userService.ConfirmCodeToResetPassword(request.code, request.email);

        switch (result)
        {
            case "User is not found": return BadRequest<string>("User is not found");

            case "true code": return NoContent<string>("Success confirm");

            case "false code": return BadRequest<string>("false code");

            default: return BadRequest<string>("failed to confirm");
        }
    }

    public async Task<Response<string>> Handle(
        ResetPassword request,
        CancellationToken cancellationToken)
    {
        var result = await userService.ResetPassword(
            request.email,
            request.password);

        switch (result)
        {
            case "User is not found": return BadRequest<string>("User is not found");

            case "Success operation": return NoContent<string>("Successful reset password");

            case "fail": return BadRequest<string>("Failed to reset password");

            default: return BadRequest<string>("Failed to reset password");
        }
    }
}
