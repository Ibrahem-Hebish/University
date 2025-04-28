namespace UniversityProject.Core.CQSR.Commands.AuthonticationCommands;

public class RefreshTokenCommand
    : RefreshTokenDto, IRequest<Response<JwtToken>>
{ }
