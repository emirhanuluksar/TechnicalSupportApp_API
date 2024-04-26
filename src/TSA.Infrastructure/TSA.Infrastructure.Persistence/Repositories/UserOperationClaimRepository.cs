using TSA.Core.Application.Repositories;
using TSA.Infrastructure.Persistence.Contexts;
using TSA.Infrastructure.Persistence.Repositories.Common;
using TSA.Infrastructure.Security.Entities;

namespace TSA.Infrastructure.Persistence.Repositories;

public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, int, TSADbContext>, IUserOperationClaimRepository
{
    public UserOperationClaimRepository(TSADbContext dbContext) : base(dbContext)
    {
    }
}