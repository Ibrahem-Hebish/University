namespace UniversityProject.Core.CQSR.Handlers.UserHandler.Queries;

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
        if (request.Id <= 0)
            return BadRequest<GetUserDto>("Id must be greater than 0");

        var user = await userManager.FindByIdAsync(request.Id.ToString());

        if (user is null) return NotFouned<GetUserDto>();

        var GetUser = mapper.Map<GetUserDto>(user);

        return Success(GetUser);
    }
}
