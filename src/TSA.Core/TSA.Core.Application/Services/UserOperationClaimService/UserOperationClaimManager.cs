using Microsoft.EntityFrameworkCore;
using TSA.Core.Application.Repositories.Common;
using TSA.Infrastructure.Security.Entities;

namespace TSA.Core.Application.Services.UserOperationClaimService;

public class UserOperationClaimManager(IUnitOfWork unitOfWork) : IUserOperationClaimService
{
    public async Task<IList<OperationClaim>> GetClaimsByUserId(Guid id)
    {
        return await unitOfWork.UserOperationClaimRepository
            .Query()
            .AsNoTracking()
            .Where(p => p.UserId == id)
            .Select(p => new OperationClaim { Id = p.OperationClaimId, OperationClaimName = p.OperationClaim.OperationClaimName })
            .ToListAsync();
    }
}