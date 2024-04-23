using Microsoft.AspNetCore.Builder;
using TSA.Infrastructure.Infrastructure.CrossCuttingConcerns.Exception.WebAPI.Middleware;

namespace TSA.Infrastructure.Infrastructure.CrossCuttingConcerns.Exception.WebAPI.Extensions;

public static class ApplicationBuilderExceptionMiddlewareExtensions
{
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<ExceptionMiddleware>();
}