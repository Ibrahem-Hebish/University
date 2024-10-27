﻿namespace UniversityProject.Services;

public static class DependancyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthontication, Authontication>();

        services.AddScoped<IStudentService, StudentServices>();

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
