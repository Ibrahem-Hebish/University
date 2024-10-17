using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

namespace Schoolproject.Api;

public static class DependancyInjection
{
    public static IServiceCollection AddWeb(
        this IServiceCollection services)
    {
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

        services.AddSwaggerGen();

        return services;
    }
}
