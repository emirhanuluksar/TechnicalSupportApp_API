using TSA.Core.Application.Repositories.Common;
using TSA.Infrastructure.Security.Entities;

namespace TSA.Core.Application.Repositories;

public interface IRefreshTokenRepository : IAsyncRepository<RefreshToken, int>, IRepository<RefreshToken, int>
{
    Task<List<RefreshToken>> GetRefreshTokensByUserId(Guid userId, int refreshTokenTTl);
}