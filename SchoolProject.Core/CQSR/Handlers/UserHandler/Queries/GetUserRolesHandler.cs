namespace UniversityProject.Core.CQSR.Handlers.UserHandler.Queries;

public class GetUserRolesHandler(UserManager<User> userManager,
    RoleManager<Role> roleManager, IMapper mapper) :
  ResponseHandler, IRequestHandler<GetUserRoles, Response<ManageUserRoles>>

{
    public async Task<Response<ManageUserRoles>> Handle(
        GetUserRoles request,
        CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return BadRequest<ManageUserRoles>("Id must be greater than 0");

        var user = await userManager.FindByIdAsync(request.Id.ToString());

        if (user is null)
            return BadRequest<ManageUserRoles>("User is not found");

        var userroles = await userManager.GetRolesAsync(user);

        var systemroles = await roleManager.Roles.ToListAsync();

        var manageuserroles = new ManageUserRoles
        {
            Userid = user.Id
        };
        var cusromuserroles = new List<UserRoles>();

        if (systemroles is not null && systemroles.Count > 0)
        {
            foreach (var systemrole in systemroles)
            {
                var role = new UserRoles
                {
                    Id = systemrole.Id,

                    Name = systemrole.Name!
                };

                if (userroles.Contains(systemrole.Name!))
                    role.HasRole = true;

                else role.HasRole = false;

                cusromuserroles.Add(role);
            }
        }

        else return BadRequest<ManageUserRoles>("The system has no roles.");

        manageuserroles.UserRoles = cusromuserroles;

        return Success(manageuserroles);
    }

}


