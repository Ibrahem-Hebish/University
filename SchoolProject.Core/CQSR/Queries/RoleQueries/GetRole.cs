namespace UniversityProject.Core.CQSR.Queries.RoleQueries;

public record GetRole(
    int Id)
    : IRequest<Response<GetRoleDto>>
{ }
