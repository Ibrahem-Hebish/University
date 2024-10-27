namespace UniversityProject.Core.CQSR.Handlers.UserHandler;

public class GetUserByIdHandler(
    UserManager<User> userManager,
    IMapper mapper)

    : ResponseHandler,
      IRequestHandler<GetUserById, Response<GetUserDto>>
{
    public async Task<Response<GetUserDto>> Handle(
        GetUserById request,
        CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.id.ToString());

        if (user is null) return NotFouned<GetUserDto>();

        var GetUser = mapper.Map<GetUserDto>(user);

        return Success(GetUser);
    }
}
