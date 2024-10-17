using Microsoft.Extensions.Options;

namespace SchoolProject.Services.Services;

public class Authontication(
    IOptionsMonitor<JwtOptions> jwtOptions,
    IUserTokenRepository userTokenRepository,
    IConfiguration configuration,
    UserManager<User> userManager)

        : IAuthontication
{

    private const string _secretToken =
        "QWERTYUIOPLKJHGFDSAZXCVBNMqwertyuioplkjhgfdsamnbvcxz1230987654*&^$@#";

    public async Task<JwtToken> CreateToken(User user)
    {
        var AccessToken = await CreateAccessToken(user);

        var jwtToken = CreateJwtToken(user, AccessToken);

        var userToken = new UserToken()
        {
            IsUsed = true,
            IsExpired = false,
            AccessToken = AccessToken,
            Token = jwtToken.Token.Token,
            AddedDate = DateTime.UtcNow,
            ExpiredDate = jwtToken.Token.ExpirationDate,
            Userid = user.Id,
        };

        await userTokenRepository.AddAsync(userToken);

        return jwtToken;
    }

    public JwtSecurityToken DecodeAccessToken(string AccessToken)
    {
        if (String.IsNullOrEmpty(AccessToken))
            return null!;

        var TokenHandler = new JwtSecurityTokenHandler();

        var SecurityToken = TokenHandler.ReadJwtToken(AccessToken);

        return SecurityToken;
    }

    public async Task<string> ValidateToken(string AccessToken)
    {
        var TokenHandler = new JwtSecurityTokenHandler();

        var Parametars = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = jwtOptions.CurrentValue.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtOptions.CurrentValue.Audience,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    configuration["signingkey"]!))
        };
        var Result = await TokenHandler.ValidateTokenAsync(AccessToken,
                                                           Parametars);

        if (Result is null)
            return "Invalid Token";

        return "Success";
    }

    public Task<JwtToken> RefreshToken(User user,
                                      string Token,
                                      DateTime expireddate)
    {
        var jwtToken = CreateJwtToken(user, Token);

        jwtToken.Token.ExpirationDate = expireddate;

        return Task.FromResult(jwtToken);
    }

    public async Task<string> ValidateDetails(JwtSecurityToken jwtSecurityToken,
                                              string AccessToken,
                                              string Token)
    {
        if (jwtSecurityToken is null)
            return "Access Token is null";

        if (!jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
            return "Algorism is wrong";

        if (jwtSecurityToken.ValidTo > DateTime.UtcNow)
            return "Token is not expired";

        var userToken = await userTokenRepository
                 .GetOneAsync(rt => rt.Token == Token &&
                 rt.AccessToken == AccessToken);

        if (userToken is null)
            return "Invalid Token";

        if (userToken.ExpiredDate < DateTime.UtcNow)
        {
            userToken.IsExpired = true;
            userToken.IsUsed = false;
            await userTokenRepository.UpdateAsync(userToken);
            return ("Refresh Token is expired");
        }

        var Userid = userToken.Id;

        return $"{Userid},{userToken.ExpiredDate}";
    }

    private async Task<string> CreateAccessToken(User user)
    {
        var TokenHandler = new JwtSecurityTokenHandler();

        var signingkey = configuration["signingkey"];

        var TokenDescriptor = new SecurityTokenDescriptor()
        {
            Issuer = jwtOptions.CurrentValue.Issuer,

            Audience = jwtOptions.CurrentValue.Audience,

            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                        signingkey!)),
                SecurityAlgorithms.HmacSha256),

            Subject = await GetClaims(user),

            Expires = DateTime.UtcNow.AddDays(jwtOptions.CurrentValue.LifeTime)

        };

        var SecurityToken = TokenHandler.CreateToken(TokenDescriptor);

        var AccessToken = TokenHandler.WriteToken(SecurityToken);

        return AccessToken;
    }

    private async Task<ClaimsIdentity> GetClaims(User user)
    {

        var UserClaims = await userManager.GetClaimsAsync(user);

        var claimsidentity = new ClaimsIdentity(UserClaims);

        return claimsidentity;
    }

    private static string GenereteToken()
    {
        StringBuilder Token = new();

        for (int i = 0; i < 32; i++)
            Token.Append(_secretToken[Random.Shared.Next(0, 68)]);

        return Token.ToString();
    }

    private static JwtToken CreateJwtToken(User user,
                                           string AccessToken)
    {
        var jwtToken = new JwtToken()
        {
            AccessToken = AccessToken,
            Token = new RefreshToken()
            {
                UserName = user.UserName!,
                Token = GenereteToken(),
                ExpirationDate = DateTime.UtcNow.AddMonths(1)
            }
        };
        return jwtToken;
    }

}
