using Application.Common.Behaviors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            {
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
                cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        return services;
    }
}