namespace SchoolProject.Core.CQSR.Handlers.UserHandler;

public class AddUserHandler(IUserService userService, IMapper mapper) :
    ResponseHandler,
    IRequestHandler<AddNewUser, Response<string>>

{

    public async Task<Response<string>> Handle(
        AddNewUser request,
        CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request.addUser);

        var result = await userService.Register(user, request.addUser.Password);

        switch (result)
        {
            case "Try another username": return BadRequest<string>("Try another username");

            case "Try another email": return BadRequest<string>("Try another email");

            case "success": return NoContent<string>("Please confirm your email to complate the registeration");

            case "Failed To register": return BadRequest<string>("Failed To register");

            default: return BadRequest<string>(result);
        }
    }
}
