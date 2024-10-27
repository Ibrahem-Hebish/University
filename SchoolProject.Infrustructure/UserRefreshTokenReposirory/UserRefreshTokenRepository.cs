namespace UniversityProject.Infrustructure.UserRefreshTokenReposirory;

public class UserTokenRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
        : UniversityRepositery<UserToken>(appDbContext, memoryCache)
    , IUserTokenRepository
{
}
