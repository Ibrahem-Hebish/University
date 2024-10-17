namespace SchoolProject.Core.Mapping.UserMappping;

public partial class UserMappings
{
    public void GetUser()
    {
        CreateMap<User, GetUserDto>();
    }
}
