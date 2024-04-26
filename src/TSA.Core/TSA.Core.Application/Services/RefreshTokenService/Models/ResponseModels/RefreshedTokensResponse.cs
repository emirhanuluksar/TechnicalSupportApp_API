using TSA.Infrastructure.Security.Entities;
using TSA.Infrastructure.Security.Helpers.JWTHelpers;

namespace TSA.Core.Application.Services.RefreshTokenService.Models.ResponseModels;

public record RefreshedTokensResponse(AccessToken? AccessToken, RefreshToken? RefreshToken)
{
    public RefreshedTokensResponse() : this(null, null)
    {
    }
}