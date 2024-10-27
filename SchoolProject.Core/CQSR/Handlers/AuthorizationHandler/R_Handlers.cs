using Claim = System.Security.Claims.Claim;

namespace UniversityProject.Core.CQSR.Handlers.RoleHandler;

public class RoleHandler(
    AppDbContext appDbContext,
    IRoleServices roleServices,
    IMapper mapper,
    UserManager<User> usermanager,
    RoleManager<Role> rolemanager)

    : ResponseHandler, IRequestHandler<AddRoleCommand, Response<string>>,
    IRequestHandler<DeleteRole, Response<string>>,
    IRequestHandler<UpdateRole, Response<string>>,
    IRequestHandler<GetRoles, Response<List<GetRoleDto>>>,
    IRequestHandler<GetRole, Response<GetRoleDto>>,
    IRequestHandler<GetUserRoles, Response<ManageUserRoles>>,
    IRequestHandler<GetUserClaims, Response<Manageuserclaims>>,
    IRequestHandler<Updateuserclaims, Response<string>>
{
    private readonly IRoleServices _roleServices = roleServices;
    private readonly AppDbContext _appDbContext = appDbContext;
    private readonly IMapper mapper = mapper;
    private readonly UserManager<User> userManager = usermanager;
    private readonly RoleManager<Role> _rolemanager = rolemanager;

    public async Task<Response<string>> Handle(
        AddRoleCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _roleServices.AddRoleAsync(request.name);

        if (result == "Success")
            return Created<string>();

        return BadRequest<string>("Failed to add");
    }

    public async Task<Response<string>> Handle(
        DeleteRole request,
        CancellationToken cancellationToken)
    {
        var result = await _roleServices.DeleteRole(request.id);
        switch (result)
        {
            case "Not found":
                return NotFouned<string>("There is no role with ths id");
            case "Server error":
                return InternalServerError<string>("Error happens while deleting the data");
        }
        return Deleted<string>();
    }

    public async Task<Response<string>> Handle(
        UpdateRole request,
        CancellationToken cancellationToken)
    {
        var result = await _roleServices.UpdateRole(request.currentName, request.newName);

        switch (result)
        {
            case "Bad request":
                return BadRequest<string>("There is no role with ths name");

            case "Server error":
                return InternalServerError<string>("Error happens while deleting the data");

        }

        return Success("Data is updated");
    }

    public async Task<Response<List<GetRoleDto>>> Handle(
        GetRoles request,
        CancellationToken cancellationToken)
    {
        var result = await _roleServices.GetRolesAsync();

        if (result is null)
            return NotFouned<List<GetRoleDto>>();

        var rolesDtos = mapper.Map<List<GetRoleDto>>(result);

        return Success(rolesDtos);
    }

    public async Task<Response<GetRoleDto>> Handle(
        GetRole request,
        CancellationToken cancellationToken)
    {
        var result = await _roleServices.GetRoleAsync(request.id);

        if (result is null)
            return NotFouned<GetRoleDto>();

        var roleDto = mapper.Map<GetRoleDto>(result);

        return Success(roleDto);
    }

    public async Task<Response<ManageUserRoles>> Handle(
        GetUserRoles request,
        CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.id.ToString());

        if (user is null)
            return BadRequest<ManageUserRoles>("User is not found");

        var userroles = await userManager.GetRolesAsync(user);

        var systemroles = await _rolemanager.Roles.ToListAsync();

        var manageuserroles = new ManageUserRoles();

        manageuserroles.Userid = user.Id;

        var cusromuserroles = new List<UserRoles>();

        if (systemroles is not null && systemroles.Count > 0)
        {
            foreach (var systemrole in systemroles)
            {
                var role = new UserRoles();

                role.Id = systemrole.Id;

                role.Name = systemrole.Name!;

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

    public async Task<Response<Manageuserclaims>> Handle(
        GetUserClaims request,
        CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.id.ToString());

        if (user is null) return BadRequest<Manageuserclaims>("User is not found");

        var manageuserclaims = await _roleServices.GetManageuserclaimsAsync(user);

        return Success(manageuserclaims);
    }

    public async Task<Response<string>> Handle(
        Updateuserclaims request,
        CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Userid.ToString());

        if (user is null)
            return NotFouned<string>("User is not found");

        var userclaims = await userManager.GetClaimsAsync(user);

        using (var scope = _appDbContext.Database.BeginTransaction())
        {
            try
            {
                await userManager.RemoveClaimsAsync(user, userclaims);

                List<Claim> claims = [];

                var newclaims = request.claims
                     .Where(c => c.Value == true).ToList();

                foreach (var claim in newclaims)
                {
                    var claimToAdd = new Claim(claim.Type, $"{claim.Value}");

                    claims.Add(claimToAdd);
                }
                await userManager.AddClaimsAsync(user, claims);

                scope.Commit();
            }
            catch
            {
                scope.Rollback();

                return InternalServerError<string>("somethig wrong happend while updating the data please,try again later");
            }
        }

        return NoContent<string>("Updated Successfully");
    }
}
