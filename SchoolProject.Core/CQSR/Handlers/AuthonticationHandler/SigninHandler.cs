namespace SchoolProject.Core.CQSR.Handlers.AuthonticationHandler;

public class SignInHandler(UserManager<User> userManager, IAuthontication authonticationservice)
        : ResponseHandler,
    IRequestHandler<SignInCommand, Response<JwtToken>>
{

    public async Task<Response<JwtToken>> Handle(
        SignInCommand request,
        CancellationToken cancellationToken)
    {
        var user = await userManager.FindByNameAsync(request.UserName);

        if (user is null) return BadRequest<JwtToken>("Username or Password is wrong");

        var SignInResult = await userManager.CheckPasswordAsync(user, request.Password);

        if (!SignInResult) return BadRequest<JwtToken>("Username or Password is wrong");

        var Token = await authonticationservice.CreateToken(user);

        return Success(Token);
    }
}
