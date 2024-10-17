namespace SchoolProject.Services.AbstractionServices;

public interface IRoleServices
{
    public Task<Role> GetRoleAsync(int id);

    public Task<List<Role>> GetRolesAsync();

    public Task<string> AddRoleAsync(string roleName);

    public Task<bool> IsExsist(string roleName);

    public Task<string> UpdateRole(string currentName,
                                   string newName);

    public Task<string> DeleteRole(int id);

    public Task<Manageuserclaims> GetManageuserclaimsAsync(User user);

}
