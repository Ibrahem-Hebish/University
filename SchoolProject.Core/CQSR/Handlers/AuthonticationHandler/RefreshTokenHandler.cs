namespace UniversityProject.Core.CQSR.Handlers.AuthonticationHandler;

public class TokenHandler(
    IAuthontication authonticationservice
    , UserManager<User> userManager)
        : ResponseHandler,
    IRequestHandler<RefreshTokenCommand, Response<JwtToken>>
{

    public async Task<Response<JwtToken>> Handle(
        RefreshTokenCommand request,
        CancellationToken cancellationToken)
    {
        var jwtsecuritytoken = authonticationservice.DecodeAccessToken(
            request.AccessToken);

        var validationresult = await authonticationservice.ValidateDetails(
            jwtsecuritytoken,
            request.AccessToken,
            request.RefreshToken);

        switch (validationresult)
        {
            case "Access Token is not recognised":
                return BadRequest<JwtToken>("Access Token is not recognised");

            case "Algorism is wrong":
                return UnAuthorize<JwtToken>();

            case "AccessToken is not expired":
                return BadRequest<JwtToken>("AccessToken is not expired");

            case "Invalid Token":
                return UnAuthorize<JwtToken>();

            case "Refresh Token is expired":
                return BadRequest<JwtToken>("Refresh Token is expired");
        }

        var Userid = int.Parse(
            validationresult!.Substring(
                validationresult.IndexOf(",")));

        var Tokenexpireddate = (DateTime)Enum.Parse(
            typeof(DateTime)
            , validationresult!.Substring(
                validationresult.IndexOf(",")));

        var user = await userManager.FindByIdAsync(
            Userid.ToString());

        if (user is null)
            return BadRequest<JwtToken>("User is not founed");

        var Result = await authonticationservice.RefreshToken(user,
            request.RefreshToken,
            Tokenexpireddate);

        return Success(Result);
    }
}
