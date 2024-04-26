using TSA.Core.Application.Services.RefreshTokenService.Models.RequestModels;
using TSA.Core.Application.Services.RefreshTokenService.Models.ResponseModels;
using TSA.Infrastructure.Security.Entities;

namespace TSA.Core.Application.Services.RefreshTokenService;

public interface IRefreshTokenService
{
    Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
    Task<RefreshToken> CreateRefreshToken(User user, string ipAddress);
    Task DeleteOldRefreshTokens(Guid userId, int refreshTokenTTl);
    Task<RefreshToken?> GetRefreshTokenByToken(string? token);
    Task<RefreshToken> UpdateAsync(RefreshToken refreshToken);
    Task RevokeRefreshToken(RefreshToken refreshToken, string ipAddress, string? reason = null, string? replacedByToken = null);
    Task<RefreshToken> RotateRefreshToken(User user, RefreshToken refreshToken, string ipAddress);
    Task RevokeDescendantRefreshTokens(RefreshToken? refreshToken, string ipAddress, string reason);
    Task<RefreshedTokensResponse> RefreshToken(RefreshTokenRequest refreshTokenRequest);
    Task<RevokedTokenResponse> RevokeToken(RevokeTokenRequest revokeTokenRequest);
}