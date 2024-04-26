using Microsoft.EntityFrameworkCore;
using TSA.Core.Application.Repositories;
using TSA.Infrastructure.Persistence.Contexts;
using TSA.Infrastructure.Persistence.Repositories.Common;
using TSA.Infrastructure.Security.Entities;

namespace TSA.Infrastructure.Persistence.Repositories;

public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, int, TSADbContext>, IRefreshTokenRepository
{
    private readonly TSADbContext _dbContext;
    public RefreshTokenRepository(TSADbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<RefreshToken>> GetRefreshTokensByUserId(Guid userId, int refreshTokenTTl)
    {
        return _dbContext.RefreshTokens
            .AsQueryable()
            .AsNoTracking()
            .Where(
                r =>
                    r.UserId == userId
                    && r.RevokedDate == null
                    && r.ExpirationDate >= DateTime.UtcNow
                    && r.CreatedAt.AddDays(refreshTokenTTl) <= DateTime.UtcNow
            )
            .ToListAsync();
    }
}