using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Core.ValidationBehavior;
using SchoolProject.Core.Validators.RoleValidators;
using System.Reflection;

namespace SchoolProject.Core;

public static class DependancyInjection
{
    public static IServiceCollection AddCore(
        this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddMediatR(
            c => c.RegisterServicesFromAssembly(
                Assembly.GetExecutingAssembly()));

        services.AddValidatorsFromAssembly(typeof(AddRoleValidator).Assembly);

        services.AddScoped(
            typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}