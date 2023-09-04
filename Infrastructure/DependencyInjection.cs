using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Infrastructure.Authentication;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        
        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddTransient<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        
        return services;
    }
}