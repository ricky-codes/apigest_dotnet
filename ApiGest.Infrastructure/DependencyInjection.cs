namespace ApiGest.Infrastructure;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ApiGest.Application.Common.Interfaces.Authentication;
using ApiGest.Infrastructure.Authentication;
using ApiGest.Application.Common.Interfaces.Services;
using ApiGest.Infrastructure.Services;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
}

