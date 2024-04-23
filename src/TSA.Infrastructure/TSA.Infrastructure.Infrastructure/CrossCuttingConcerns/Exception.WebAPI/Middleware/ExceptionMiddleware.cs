using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using TSA.Infrastructure.Infrastructure.CrossCuttingConcerns.Exception.WebAPI.Handlers;

namespace TSA.Infrastructure.Infrastructure.CrossCuttingConcerns.Exception.WebAPI.Middleware;

public class ExceptionMiddleware(HttpExceptionHandler httpExceptionHandler, RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (System.Exception exception)
        {
            await HandleExceptionAsync(context.Response, exception);
        }
    }

    private Task HandleExceptionAsync(HttpResponse response, System.Exception exception)
    {
        response.ContentType = MediaTypeNames.Application.Json;
        httpExceptionHandler.Response = response;
        return httpExceptionHandler.HandleException(exception);
    }
}