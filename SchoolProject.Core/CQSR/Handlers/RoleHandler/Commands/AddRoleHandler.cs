namespace UniversityProject.Core.CQSR.Handlers.RoleHandler.Commands;

public class AddRoleHandler(IRoleServices roleServices) :
  ResponseHandler, IRequestHandler<AddRoleCommand, Response<string>>

{
    public async Task<Response<string>> Handle(
         AddRoleCommand request,
         CancellationToken cancellationToken)
    {
        var result = await roleServices.AddRoleAsync(request.Name);

        if (result == "Success")
            return Created<string>();

        return BadRequest<string>("Failed to add");
    }
}


