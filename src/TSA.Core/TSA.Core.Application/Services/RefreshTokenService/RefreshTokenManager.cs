using AutoMapper;
using Microsoft.Extensions.Configuration;
using TSA.Core.Application.Repositories.Common;
using TSA.Core.Application.Services.RefreshTokenService.Models.RequestModels;
using TSA.Core.Application.Services.RefreshTokenService.Models.ResponseModels;
using TSA.Core.Application.Services.RefreshTokenService.Rules;
using TSA.Core.Application.Services.UserOperationClaimService;
using TSA.Core.Application.Services.UserService;
using TSA.Infrastructure.Security.Entities;
using TSA.Infrastructure.Security.Helpers.JWTHelpers;

namespace TSA.Core.Application.Services.RefreshTokenService;

public class RefreshTokenManager(IUnitOfWork unitOfWork, ITokenHelper tokenHelper, RefreshTokenBusinessRules refreshTokenBusinessRules, IUserService userService, IConfiguration configuration, IMapper mapper, IUserOperationClaimService userOperationClaimService) : IRefreshTokenService
{
    public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
    {
        return unitOfWork.RefreshTokenRepository.AddAsync(refreshToken);
    }

    public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
    {
        RefreshToken refreshToken = tokenHelper.CreateRefreshToken(user, ipAddress);
        return Task.FromResult(refreshToken);
    }

    public async Task DeleteOldRefreshTokens(Guid userId, int refreshTokenTTl)
    {
        List<RefreshToken> refreshTokens = await unitOfWork.RefreshTokenRepository.GetRefreshTokensByUserId(userId, refreshTokenTTl);



        await unitOfWork.RefreshTokenRepository.DeleteRangeAsync(refreshTokens);
    }

    public Task<RefreshToken?> GetRefreshTokenByToken(string? token)
    {
        return unitOfWork.RefreshTokenRepository.GetAsync(rt => rt.Token == token);
    }

    public async Task<RefreshedTokensResponse> RefreshToken(RefreshTokenRequest refreshTokenRequest)
    {
        RefreshToken resultRefreshToken = await refreshTokenBusinessRules.RefreshTokenShouldBeExists(await GetRefreshTokenByToken(refreshTokenRequest.RefreshToken));
        if (resultRefreshToken.RevokedDate != null)
            await RevokeDescendantRefreshTokens(
                resultRefreshToken,
                refreshTokenRequest.IpAddress,
                reason: $"Attempted reuse of revoked ancestor token: {resultRefreshToken.Token}"
            );

        await refreshTokenBusinessRules.RefreshTokenShouldBeActive(resultRefreshToken);
        User user = await userService.GetUserById(resultRefreshToken.UserId);
        RefreshToken newRefreshToken = await RotateRefreshToken(user, resultRefreshToken, refreshTokenRequest.IpAddress);
        RefreshToken addedRefreshToken = await AddRefreshToken(newRefreshToken);

        await DeleteOldRefreshTokens(resultRefreshToken.UserId, configuration.GetSection("TokenOptions:RefreshTokenTTL").Get<int>());

        AccessToken createdAccessToken = await CreateAccessToken(user);

        RefreshedTokensResponse refreshedTokensResponse = new(createdAccessToken, addedRefreshToken);

        return refreshedTokensResponse;
    }

    public async Task<AccessToken> CreateAccessToken(User user)
    {
        IList<OperationClaim> operationClaims = await userOperationClaimService.GetClaimsByUserId(user.Id);
        AccessToken accessToken = tokenHelper.CreateToken(user, operationClaims);
        return accessToken;
    }

    public async Task RevokeDescendantRefreshTokens(RefreshToken? refreshToken, string ipAddress, string reason)
    {
        RefreshToken? childToken = await GetRefreshTokenByToken(refreshToken?.ReplacedByToken);

        if (childToken != null && childToken.RevokedDate != null && childToken.ExpirationDate <= DateTime.UtcNow)
            await RevokeRefreshToken(childToken, ipAddress, reason);
        else
            await RevokeDescendantRefreshTokens(childToken, ipAddress, reason);
    }

    public async Task RevokeRefreshToken(RefreshToken refreshToken, string ipAddress, string? reason = null, string? replacedByToken = null)
    {
        refreshToken.RevokedDate = DateTime.UtcNow;
        refreshToken.RevokedByIp = ipAddress;
        refreshToken.ReasonRevoked = reason;
        refreshToken.ReplacedByToken = replacedByToken;
        await UpdateAsync(refreshToken);
    }

    public async Task<RevokedTokenResponse> RevokeToken(RevokeTokenRequest revokeTokenRequest)
    {
        RefreshToken resultRefreshToken = await refreshTokenBusinessRules.RefreshTokenShouldBeExists(await GetRefreshTokenByToken(revokeTokenRequest.Token));
        await refreshTokenBusinessRules.RefreshTokenShouldBeActive(resultRefreshToken);
        await RevokeRefreshToken(resultRefreshToken, revokeTokenRequest.IpAddress, reason: "Revoked without replacement");

        RevokedTokenResponse revokedTokenResponse = mapper.Map<RevokedTokenResponse>(resultRefreshToken);
        return revokedTokenResponse;
    }

    public async Task<RefreshToken> RotateRefreshToken(User user, RefreshToken refreshToken, string ipAddress)
    {
        RefreshToken newRefreshToken = tokenHelper.CreateRefreshToken(user, ipAddress);
        await RevokeRefreshToken(refreshToken, ipAddress, reason: "Replaced by new token", newRefreshToken.Token);
        return newRefreshToken;
    }

    public async Task<RefreshToken> UpdateAsync(RefreshToken refreshToken)
    {
        var updatedRefreshToken = await unitOfWork.RefreshTokenRepository.UpdateAsync(refreshToken);
        return updatedRefreshToken;
    }
}