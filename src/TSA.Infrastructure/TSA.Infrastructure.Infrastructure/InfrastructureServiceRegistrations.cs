using Microsoft.Extensions.DependencyInjection;
using TSA.Infrastructure.Infrastructure.FileService;

namespace TSA.Infrastructure.Infrastructure;

public static class InfrastructureServiceRegistrations
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {

        services.AddScoped<IFileService, FileManager>();
        return services;

    }
}