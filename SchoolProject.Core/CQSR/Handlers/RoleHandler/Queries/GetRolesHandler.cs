namespace UniversityProject.Core.CQSR.Handlers.RoleHandler.Queries;

public class GetRolesHandler(IRoleServices roleServices, IMapper mapper) :
  ResponseHandler, IRequestHandler<GetRoles, Response<List<GetRoleDto>>>

{
    public async Task<Response<List<GetRoleDto>>> Handle(
        GetRoles request,
        CancellationToken cancellationToken)
    {

        var result = await roleServices.GetRolesAsync();

        if (result is null)
            return NotFouned<List<GetRoleDto>>();

        var rolesDtos = mapper.Map<List<GetRoleDto>>(result);

        return Success(rolesDtos);
    }

}


