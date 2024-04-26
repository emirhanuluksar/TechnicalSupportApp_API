using TSA.Core.Application.Rules;
using TSA.Core.Application.Services.RefreshTokenService.Constants;
using TSA.Infrastructure.Infrastructure.CrossCuttingConcerns.Exception.Types;
using TSA.Infrastructure.Security.Entities;

namespace TSA.Core.Application.Services.RefreshTokenService.Rules;

public class RefreshTokenBusinessRules : BaseBusinessRules
{
    public Task<RefreshToken> RefreshTokenShouldBeExists(RefreshToken? refreshToken)
    {
        if (refreshToken == null)
            throw new BusinessException(RefreshTokenMessages.RefreshDontExists);
        return Task.FromResult(refreshToken);
    }

    public Task RefreshTokenShouldBeActive(RefreshToken refreshToken)
    {
        if (refreshToken.RevokedDate != null && DateTime.UtcNow >= refreshToken.ExpirationDate)
            throw new BusinessException(RefreshTokenMessages.InvalidRefreshToken);
        return Task.CompletedTask;
    }
}