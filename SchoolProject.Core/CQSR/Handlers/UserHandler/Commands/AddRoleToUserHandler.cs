namespace UniversityProject.Core.CQSR.Handlers.UserHandler.Commands;

public class AddRoleToUserHandler(
    UserManager<User> userManager,
    RoleManager<Role> roleManager)
    : ResponseHandler
    , IRequestHandler<AddRoleToUser, Response<bool>>
{

    public async Task<Response<bool>> Handle(
        AddRoleToUser request,
        CancellationToken cancellationToken)
    {
        var rolename = $"{request.Role.Substring(0, 1).ToUpperInvariant()}" +
            $"{request.Role.Substring(1).ToLowerInvariant()}";

        var result = await roleManager.Roles.Select(x => x.Name).ContainsAsync(rolename);

        if (!result)
            return NotFouned<bool>("Role is not found");

        var user = await userManager.FindByNameAsync(request.Username);

        if (user is null)
            return NotFouned<bool>("User not found");

        var finalresult = await userManager.AddToRoleAsync(user, rolename);

        if (!finalresult.Succeeded)
            return InternalServerError<bool>();

        return Success(true);
    }
}
