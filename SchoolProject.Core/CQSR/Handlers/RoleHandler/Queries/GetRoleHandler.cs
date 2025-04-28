namespace UniversityProject.Core.CQSR.Handlers.RoleHandler.Queries;

public class GetRoleHandler(IRoleServices roleServices, IMapper mapper) :
  ResponseHandler, IRequestHandler<GetRole, Response<GetRoleDto>>

{
    public async Task<Response<GetRoleDto>> Handle(
         GetRole request,
         CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return BadRequest<GetRoleDto>("Id must be greater than 0");
        var result = await roleServices.GetRoleAsync(request.Id);

        if (result is null)
            return NotFouned<GetRoleDto>();

        var roleDto = mapper.Map<GetRoleDto>(result);

        return Success(roleDto);
    }

}


