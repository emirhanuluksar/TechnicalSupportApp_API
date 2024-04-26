using TSA.Core.Application.Repositories.Common;
using TSA.Infrastructure.Security.Entities;

namespace TSA.Core.Application.Repositories;

public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim, int>, IRepository<UserOperationClaim, int>
{

}