using TSA.Core.Domain.Entities.Common;

namespace TSA.Infrastructure.Security.Entities;

public class RefreshToken : Entity<int>
{
    public Guid UserId { get; set; }
    public string Token { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
    public string CreatedByIp { get; set; } = string.Empty;
    public DateTime? RevokedDate { get; set; }
    public string? RevokedByIp { get; set; }
    public string? ReplacedByToken { get; set; }
    public string? ReasonRevoked { get; set; }


    public User User { get; set; } = null!;
}