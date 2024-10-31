namespace UniversityProject.Core.CQSR.Handlers.AuthonticationHandler;

public class ValidateTokenHandler(IAuthontication authonticationService)
        : ResponseHandler,
    IRequestHandler<ValidateTokenCommand, Response<string>>
{

    public async Task<Response<string>> Handle(
        ValidateTokenCommand request,
        CancellationToken cancellationToken)
    {
        if (String.IsNullOrEmpty(request.AccessToken))
            return BadRequest<string>("Access token can not be null or empty");

        var result = await authonticationService.ValidateToken(request.AccessToken);

        if (result == "Invalid Token")
            return BadRequest<string>("Invalid Token");

        return Success(request.AccessToken);
    }
}
