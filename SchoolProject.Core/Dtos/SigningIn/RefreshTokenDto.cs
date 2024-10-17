namespace SchoolProject.Core.Dtos.SigningIn;

public class RefreshTokenDto
{
    public string AccessToken { get; set; } = null!;

    public string RefreshToken { get; set; } = null!;
}
