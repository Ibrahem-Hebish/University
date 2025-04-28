namespace UniversityProject.Core.CQSR.Queries.RoleQueries;
public record GetUserClaims(
    int Id)
    : IRequest<Response<ManageUserClaims>>
{ }
