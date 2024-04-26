using TSA.Core.Domain.Entities.Common;

namespace TSA.Infrastructure.Security.Entities;

public class OperationClaim : Entity<int>
{
    public string OperationClaimName { get; set; } = string.Empty;
    public ICollection<UserOperationClaim> UserOperationClaims { get; set; } = new HashSet<UserOperationClaim>();
}