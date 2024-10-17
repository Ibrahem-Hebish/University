namespace SchoolProject.Services.AbstractionServices;

public interface IAuthontication
{
    public Task<string> ValidateToken(
                                     string AccessToken);

    public JwtSecurityToken DecodeAccessToken(
                                             string AccessToken);

    public Task<JwtToken> CreateToken(User user);
    public Task<JwtToken> RefreshToken(User user,
                                string Token,
                                DateTime expireddate);
    public Task<string> ValidateDetails(JwtSecurityToken jwtSecurityToken,
                                        string AccessToken,
                                        string Token);
}
