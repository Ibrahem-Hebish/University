using Microsoft.Extensions.DependencyInjection;
using UniversityProject.Core.ValidationBehavior;
using UniversityProject.Core.Validators.RoleValidators;
using System.Reflection;

namespace UniversityProject.Core;

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