using TSA.Core.Application.Repositories;
using TSA.Infrastructure.Persistence.Contexts;
using TSA.Infrastructure.Persistence.Repositories.Common;
using TSA.Infrastructure.Security.Entities;

namespace TSA.Infrastructure.Persistence.Repositories;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim, int, TSADbContext>, IOperationClaimRepository
{
    public OperationClaimRepository(TSADbContext dbContext) : base(dbContext)
    {
    }
}