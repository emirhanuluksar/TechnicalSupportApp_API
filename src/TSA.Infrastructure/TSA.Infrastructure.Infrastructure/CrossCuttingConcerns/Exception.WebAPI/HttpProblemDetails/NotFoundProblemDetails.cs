using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSA.Infrastructure.Infrastructure.CrossCuttingConcerns.Exception.WebAPI.HttpProblemDetails;

public class NotFoundProblemDetails : ProblemDetails
{
    public NotFoundProblemDetails(string detail)
    {
        Title = "Not found";
        Detail = detail;
        Status = StatusCodes.Status404NotFound;
        Type = "https://example.com/probs/not-found";
    }
}