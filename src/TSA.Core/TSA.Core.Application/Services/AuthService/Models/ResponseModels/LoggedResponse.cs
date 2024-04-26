using TSA.Infrastructure.Security.Entities;
using TSA.Infrastructure.Security.Helpers.JWTHelpers;

namespace TSA.Core.Application.Services.AuthService.Models.ResponseModels;

public record LoggedResponse(AccessToken? AccessToken, RefreshToken? RefreshToken)
{
    public LoggedResponse() : this(null, null)
    {
    }
    public LoggedHttpResponse ToHttpResponse() =>
        new LoggedHttpResponse { AccessToken = AccessToken };
}

public class LoggedHttpResponse
{
    public AccessToken? AccessToken { get; init; }
    // public AuthenticatorType? RequiredAuthenticatorType { get; set; }
}