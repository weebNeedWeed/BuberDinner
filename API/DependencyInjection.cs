using Api.Common.Errors;
using API.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddTransient<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
        services.AddControllers();
        services.AddMappings();
        
        return services;
    }
}