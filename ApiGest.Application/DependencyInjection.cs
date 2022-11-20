namespace ApiGest.Application;

using Microsoft.Extensions.DependencyInjection;
using ApiGest.Application.Services.Authentication;

public static class DependencyInjection {
    public static IServiceCollection AddApplication(this IServiceCollection services) {
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }
}