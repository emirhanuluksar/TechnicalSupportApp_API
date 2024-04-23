using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace TSA.Infrastructure.Infrastructure.CrossCuttingConcerns.Exception.WebAPI.Extensions;

public static class ProblemDetailsException
{
    public static string ToJson<TProblemDetail>(this TProblemDetail details)
        where TProblemDetail : ProblemDetails => JsonSerializer.Serialize(details);
}