namespace SchoolProject.Infrustructure.UserRefreshTokenReposirory;

public class UserTokenRepository(AppDbContext appDbContext)
        : SchoolRepositery<UserToken>(appDbContext)
    , IUserTokenRepository
{
}
