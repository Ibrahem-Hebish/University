namespace UniversityProject.Core.CQSR.Handlers.UserHandler.Queries;

internal class GetUsersHandler(
    UserManager<User> userManager,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetUsers, Response<List<GetUserDto>>>,
    IRequestHandler<CheckIfEmailExsist, Response<bool>>
{
    public async Task<Response<List<GetUserDto>>> Handle(
        GetUsers request,
        CancellationToken cancellationToken)
    {
        var users = await userManager.Users.ToListAsync(cancellationToken: cancellationToken);

        if (users.Count == 0) return NotFouned<List<GetUserDto>>();

        var GetUser = mapper.Map<List<GetUserDto>>(users);

        return Success(GetUser);
    }

    public async Task<Response<bool>> Handle(CheckIfEmailExsist request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Email))
            return BadRequest<bool>("Email is required");

        var user = await userManager.FindByEmailAsync(request.Email);

        if (user is null)
            return NotFouned<bool>("This email is not used");

        return Success(true, "This email is used by another user");

    }
}

