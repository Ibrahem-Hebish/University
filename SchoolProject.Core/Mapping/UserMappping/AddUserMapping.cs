namespace UniversityProject.Core.Mapping.UserMappping;

public partial class UserMappings
{
    public void AddUser()
    {
        CreateMap<AddUser, User>();
    }
}
