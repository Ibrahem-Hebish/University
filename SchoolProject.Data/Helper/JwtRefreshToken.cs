namespace SchoolProject.Data.Helper;

public class JwtToken
{
    public string AccessToken { get; set; } = null!;

    public RefreshToken Token { get; set; } = null!;
}
public class RefreshToken
{
    public string UserName { get; set; } = null!;
    public string Token { get; set; } = null!;
    public DateTime ExpirationDate { get; set; }
}
