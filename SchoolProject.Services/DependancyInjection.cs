namespace UniversityProject.Services;

public static class DependancyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthontication, Authontication>();

        services.AddScoped<IStudentService, StudentServices>();

        services.AddScoped<IRoleServices, RoleServices>();

        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IEmailService, EmailService>();

        var configuration = new ConfigurationBuilder().AddJsonFile("ServiceSettings.json")
             .Build();

        services.Configure<SendEmailSetting>(configuration.GetSection("Email"));

        services.Configure<JwtOptions>(configuration.GetSection("jwt"));

        var jwt = configuration.GetSection("jwt").Get<JwtOptions>();

        var environmentvariablesConfiguration = new ConfigurationBuilder()
            .AddEnvironmentVariables().Build();

        services.AddAuthentication()
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
                {
                    opt.SaveToken = true;

                    opt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwt!.Issuer,
                        ValidateAudience = true,
                        ValidAudience = jwt!.Audience,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(
                                environmentvariablesConfiguration["signingkey"]!))
                    };
                });

        return services;
    }
}
