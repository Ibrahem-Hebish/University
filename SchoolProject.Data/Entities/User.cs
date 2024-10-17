namespace SchoolProject.Data.Entities;

public class User : IdentityUser<int>
{
    public User()
    {
        Tokens = new HashSet<UserToken>();
    }
    public string? Country { get; set; }
    public string? Code { get; set; }
    public string? Address { get; set; }
    [InverseProperty(nameof(UserToken.User))]
    public ICollection<UserToken> Tokens { get; set; }
}
