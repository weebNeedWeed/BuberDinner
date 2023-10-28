using System.Text;

using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;

using Infrastructure.Authentication;
using Infrastructure.Persistence;
using Infrastructure.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAuth(configuration)
            .AddPersistence();

        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<BuberDinnerDbContext>(opt =>
            opt.UseSqlServer("Server=localhost;Database=BuberDinner;User Id=sa;Password=@Admin123;Encrypt=true;TrustServerCertificate=true"));

        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();
        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.GetSection(JwtSettings.SectionName).Bind(jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddTransient<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey
                            (Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true
                    };
                });

        return services;
    }
}