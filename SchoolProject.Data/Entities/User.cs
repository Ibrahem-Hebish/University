namespace UniversityProject.Data.Entities;

public class User : IdentityUser<int>
{
    public string? Country { get; set; }
    public string? Code { get; set; }
    public string? Address { get; set; }
    [InverseProperty(nameof(UserToken.User))]
    public virtual List<UserToken> Tokens { get; set; } = [];
    public string? OfficeName { get; set; }
    [ForeignKey(nameof(OfficeName))]
    public Office Office { get; set; }
}
