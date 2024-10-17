namespace SchoolProject.Core.CQSR.Queries.RoleQueries;

public record GetRole(
    int id)
    : IRequest<Response<GetRoleDto>>
{ }

public class GetRoles
    : IRequest<Response<List<GetRoleDto>>>
{ }
public record GetUserClaims(
    int id)
    : IRequest<Response<Manageuserclaims>>
{ }
