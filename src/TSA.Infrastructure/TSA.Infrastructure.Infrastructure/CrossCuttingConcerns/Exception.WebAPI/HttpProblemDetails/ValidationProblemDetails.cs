using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSA.Infrastructure.Infrastructure.CrossCuttingConcerns.Exception.Types;

namespace TSA.Infrastructure.Infrastructure.CrossCuttingConcerns.Exception.WebAPI.HttpProblemDetails;

public class ValidationProblemDetails : ProblemDetails
{
    public IEnumerable<ValidationExceptionModel> Errors { get; set; }

    public ValidationProblemDetails(IEnumerable<ValidationExceptionModel> errors)
    {
        Title = "Validation error";
        Detail = "One or more validation errors occurred.";
        Status = StatusCodes.Status400BadRequest;
        Type = "https://example.com/probs/validation-error";
        Errors = errors;
    }
}