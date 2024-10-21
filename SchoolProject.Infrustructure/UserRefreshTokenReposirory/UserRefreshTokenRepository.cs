using Microsoft.Extensions.Caching.Memory;

namespace SchoolProject.Infrustructure.UserRefreshTokenReposirory;

public class UserTokenRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
        : SchoolRepositery<UserToken>(appDbContext, memoryCache)
    , IUserTokenRepository
{
}
