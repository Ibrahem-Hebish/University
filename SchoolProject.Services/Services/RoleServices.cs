using Claim = UniversityProject.Data.Helper.Claim;

namespace UniversityProject.Services.Services;

public class RoleServices(
    RoleManager<Role> roleManager,
    UserManager<User> userManager)

    : IRoleServices
{

    public async Task<Role> GetRoleAsync(int id)
    {
        var role = await roleManager.FindByIdAsync(id.ToString());

        if (role is null)
            return null!;

        return role;
    }

    public async Task<List<Role>> GetRolesAsync()
    {
        var roles = await roleManager.Roles.ToListAsync();

        if (roles is null || roles.Count == 0)
            return null!;

        return roles;
    }

    public async Task<string> AddRoleAsync(string roleName)
    {
        roleName = Capitalize(roleName);

        var identityrole = new Role() { Name = roleName };

        var result = await roleManager.CreateAsync(identityrole);

        if (result.Succeeded)
            return "Success";

        return "Failed";
    }

    public async Task<bool> IsExsist(string roleName)
    {
        return await roleManager.RoleExistsAsync(roleName);
    }

    public async Task<string> DeleteRole(int id)
    {
        var role = await roleManager.FindByIdAsync(id.ToString());

        if (role is null) return "Not found";

        var result = await roleManager.DeleteAsync(role);

        if (!result.Succeeded) return "Server error";

        return "Success";

    }
    public async Task<string> UpdateRole(string currentName,
                                         string newName)
    {
        currentName = Capitalize(currentName);

        newName = Capitalize(newName);

        var role = await roleManager.FindByNameAsync(currentName);

        if (role is null) return "Bad request";

        role.Name = newName;

        var result = await roleManager.UpdateAsync(role);

        if (!result.Succeeded) return "Server error";

        return "Success";
    }

    public async Task<Manageuserclaims> GetManageuserclaimsAsync(User user)
    {
        var manageuserclaims = new Manageuserclaims
        {
            Userid = user.Id
        };

        var systemclims = SystemClaims.GetSystemClaims();

        var usercurrentclaims = await userManager.GetClaimsAsync(user);

        List<Claim> claims = [];

        foreach (var systemclim in systemclims)
        {
            var claim = new Claim
            {
                Type = systemclim.Type
            };

            if (usercurrentclaims.Any(c => c.Type == systemclim.Type))
            {
                claim.Value = true;
            }

            else claim.Value = false;

            claims.Add(claim);
        }
        manageuserclaims.claims = claims;

        return manageuserclaims;
    }
    private static string Capitalize(string value)
    {
        return $"{value[..1].ToUpperInvariant()}" +
            $"{value[1..].ToLowerInvariant()}";
    }
}
