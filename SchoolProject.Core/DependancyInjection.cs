﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UniversityProject.Core.ValidationBehavior;
using UniversityProject.Core.Validators.RoleValidators;

namespace UniversityProject.Core;

public static class DependancyInjection
{
    public static IServiceCollection AddCore(
        this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
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