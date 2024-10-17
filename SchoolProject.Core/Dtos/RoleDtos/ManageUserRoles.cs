namespace SchoolProject.Core.Dtos.RoleDtos;

public class ManageUserRoles
{
    public int Userid { get; set; }

    public List<UserRoles> UserRoles { get; set; } = null!;
}
public class UserRoles
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool HasRole { get; set; }
}
