namespace ApiGest.Infrastructure;

using Microsoft.Extensions.DependencyInjection;
using ApiGest.Application.Common.Interfaces.Authentication;
using ApiGest.Infrastructure.Authentication;
using ApiGest.Application.Common.Interfaces.Services;
using ApiGest.Infrastructure.Services;
using ApiGest.Application.Common.Interfaces.Persistance;
using ApiGest.Infrastructure.Persistance;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services) {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}

