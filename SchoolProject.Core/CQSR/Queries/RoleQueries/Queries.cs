namespace UniversityProject.Core.CQSR.Queries.RoleQueries;

public record GetRole(
    int Id)
    : IRequest<Response<GetRoleDto>>
{ }

public class GetRoles
    : IRequest<Response<List<GetRoleDto>>>
{ }
public record GetUserClaims(
    int Id)
    : IRequest<Response<Manageuserclaims>>
{ }
