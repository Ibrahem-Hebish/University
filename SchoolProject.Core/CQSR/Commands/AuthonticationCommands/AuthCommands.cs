namespace UniversityProject.Core.CQSR.Commands.AuthonticationCommands;

public class SignInCommand
    : SignIn, IRequest<Response<JwtToken>>
{ }

public record ValidateTokenCommand(
    string AccessToken)
    : IRequest<Response<string>>
{ }

public class RefreshTokenCommand
    : RefreshTokenDto, IRequest<Response<JwtToken>>
{ }

public record ConfirmEmailCommand(
    string code)
    : IRequest<Response<string>>
{ }
