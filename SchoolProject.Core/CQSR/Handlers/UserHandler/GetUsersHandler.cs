namespace UniversityProject.Core.CQSR.Handlers.UserHandler;

internal class GetUsersHandler(
    UserManager<User> userManager,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetUsers, Response<List<GetUserDto>>>
{
    public async Task<Response<List<GetUserDto>>> Handle(
        GetUsers request,
        CancellationToken cancellationToken)
    {
        var users = await userManager.Users.ToListAsync();

        if (users.Count() == 0) return NotFouned<List<GetUserDto>>();

        var GetUser = mapper.Map<List<GetUserDto>>(users);

        return Success(GetUser);
    }
}

