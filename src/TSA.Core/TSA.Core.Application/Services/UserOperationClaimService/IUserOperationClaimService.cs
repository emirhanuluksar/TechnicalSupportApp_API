using TSA.Infrastructure.Security.Entities;

namespace TSA.Core.Application.Services.UserOperationClaimService;

public interface IUserOperationClaimService
{
    Task<IList<OperationClaim>> GetClaimsByUserId(Guid id);
}