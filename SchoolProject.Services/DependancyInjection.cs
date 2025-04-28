namespace UniversityProject.Services;

public static class DependancyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddScoped<IAuthontication, Authontication>();

        services.AddScoped<IStudentService, StudentServices>();

        services.AddScoped<IRoleServices, RoleServices>();

        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IEmailService, EmailService>();

        //services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();

        var configuration = new ConfigurationBuilder().AddJsonFile("ServiceSettings.json")
             .AddEnvironmentVariables()
             .Build();

        services.Configure<SendEmailSetting>(configuration.GetSection("Email"));

        services.Configure<JwtOptions>(configuration.GetSection("jwt"));

        var jwt = configuration.GetSection("jwt").Get<JwtOptions>();

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
                                configuration["signingkey"]!))
                    };
                });

        return services;
    }
}
