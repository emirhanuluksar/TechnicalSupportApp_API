using TSA.Infrastructure.Security.Entities;
using TSA.Infrastructure.Security.Helpers.JWTHelpers;

namespace TSA.Core.Application.Services.AuthService.Models.ResponseModels;

public record RegisteredResponse(AccessToken? AccessToken, RefreshToken? RefreshToken)
{
    public RegisteredResponse() : this(null, null)
    {
    }
}