namespace UniversityProject.Core.CQSR.Handlers.UserHandler.Commands;

public class ChangePasswordHandler(
    UserManager<User> userManager)
    : ResponseHandler
    , IRequestHandler<ChangePassword, Response<string>>
{
    private readonly UserManager<User> userManager = userManager;

    public async Task<Response<string>> Handle(
        ChangePassword request,
        CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);

        if (user is null)
            return BadRequest<string>("Emial or password is wrong");

        var checkpassword = await userManager.CheckPasswordAsync(user, request.Password);

        if (!checkpassword)
            return BadRequest<string>("Emial or password is wrong");

        var result = await userManager.ChangePasswordAsync(
                                                           user,
                                                           request.Password,
                                                           request.Newpassword);

        if (!result.Succeeded)
            return InternalServerError<string>();

        return Success(request.Newpassword);
    }
}
