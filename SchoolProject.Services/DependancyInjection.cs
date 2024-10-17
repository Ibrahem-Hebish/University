namespace SchoolProject.Services;

public static class DependancyInjection
{
    private static readonly IConfiguration configuration;
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthontication, Authontication>();

        services.AddScoped<IStudentService, StudentServices>();

        services.AddScoped<IStudentSubjectservice, StudentSubjectservice>();

        services.AddScoped<IRoleServices, RoleServices>();

        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IEmailService, EmailService>();

        services.Configure<SendEmailSetting>(
             new ConfigurationBuilder()
             .AddJsonFile("ServiceSettings.json")
             .Build()
             .GetSection("Email"));

        services.Configure<JwtOptions>(new ConfigurationBuilder()
            .AddJsonFile("ServiceSettings.json")
            .Build()
            .GetSection("jwt"));

        var jwt = new ConfigurationBuilder()
            .AddJsonFile("ServiceSettings.json")
            .Build()
            .GetSection("jwt").Get<JwtOptions>();

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
