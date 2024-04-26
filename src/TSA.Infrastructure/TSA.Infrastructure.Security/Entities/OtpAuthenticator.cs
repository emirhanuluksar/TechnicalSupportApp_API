using TSA.Core.Domain.Entities.Common;

namespace TSA.Infrastructure.Security.Entities;

public class OtpAuthenticator : Entity<int>
{
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public byte[] SecretKey { get; set; } = Array.Empty<byte>();
    public bool IsVerified { get; set; }
}