namespace UniversityProject.Core.CQSR.Commands.AuthonticationCommands;

public class SignInCommand
    : SignIn, IRequest<Response<JwtToken>>
{ }
