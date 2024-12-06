using Microsoft.OpenApi.Models;
using Universityproject.Api.Middlewares;

namespace Universityproject.Api;

public static class DependancyInjection
{
    private static readonly string[] value = new string[] { };

    public static IServiceCollection AddWeb(
        this IServiceCollection services)
    {
        services.AddScoped<GlobalHandlingMiddleware>();

        services.AddControllers();

        services.AddRateLimiter(opt => opt
             .AddSlidingWindowLimiter(policyName: "slidingPolicy", options =>
            {
                options.PermitLimit = 4;

                options.Window = TimeSpan.FromSeconds(12);

                options.SegmentsPerWindow = 4;

                options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;

                options.QueueLimit = 2;
            }));

        services.AddTransient<IActionContextAccessor, ActionContextAccessor>();

        services.AddScoped<IUrlHelper>(opt =>
        {
            var contextaction = opt.GetRequiredService<IActionContextAccessor>().ActionContext;

            var factory = opt.GetRequiredService<IUrlHelperFactory>();

            return factory.GetUrlHelper(contextaction!);
        });

        services.AddCors(c =>
        {
            c.AddPolicy("local", p =>
            {
                p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
        });

        services.AddLocalization(opt => opt.ResourcesPath = "");

        services.Configure<RequestLocalizationOptions>(opt =>
        {
            List<CultureInfo> locales =
            [
                new("en-US"),

                new("ar-Eg")
            ];

            opt.DefaultRequestCulture = new RequestCulture("ar-Eg");

            opt.SupportedCultures = locales;

            opt.SupportedUICultures = locales;
        });

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(opt =>
        {

            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
            });
            opt.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                        }
                    },
                    value
                }

             });
        });
        return services;
    }
}
