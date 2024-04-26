using TSA.Core.Domain.Entities.Common;

namespace TSA.Infrastructure.Security.Entities;
public class UserOperationClaim : Entity<int>
{
    public Guid UserId { get; set; }
    public int OperationClaimId { get; set; }

    public User User { get; set; } = null!;
    public OperationClaim OperationClaim { get; set; } = null!;
}