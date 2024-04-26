using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TSA.Core.Application.Rules;
using TSA.Core.Application.Services.AuthService;
using TSA.Core.Application.Services.CompanyService;
using TSA.Core.Application.Services.RefreshTokenService;
using TSA.Core.Application.Services.UserOperationClaimService;
using TSA.Core.Application.Services.UserService;

namespace TSA.Core.Application;

public static class ApplicationServiceRegistrations
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddScoped<ICompanyService, CompanyManager>();
        services.AddScoped<IUserOperationClaimService, UserOperationClaimManager>();
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IRefreshTokenService, RefreshTokenManager>();
        services.AddScoped<IAuthService, AuthManager>();
        return services;
    }

    public static IServiceCollection AddSubClassesOfType
    (
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types)
            if (addWithLifeCycle is null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, item);
        return services;
    }
}