using TSA.Infrastructure.Security.Helpers.JWTHelpers;
using Microsoft.Extensions.DependencyInjection;

namespace TSA.Infrastructure.Security;

public static class SecurityServiceRegistrations
{
    public static IServiceCollection AddSecurityServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenHelper, JwtHelper>();
        return services;
    }
}