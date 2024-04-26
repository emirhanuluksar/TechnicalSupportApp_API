using TSA.Core.Domain.Entities.Common;

namespace TSA.Infrastructure.Security.Entities;

public class User : Entity<Guid>
{
    public string Username { get; set; } = string.Empty;
    public string NormalizedUserName
    {
        get => Username.ToUpperInvariant();
        set => Username = value.ToUpperInvariant();

    }
    public string Email { get; set; } = string.Empty;
    public string NormalizedEmail
    {
        get => Email.ToUpperInvariant();
        set => Email = value.ToUpperInvariant();
    }
    public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
    public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
    public bool IsEmailVerified { get; set; } = false;
    public bool Status { get; set; } = false;

    public ICollection<UserOperationClaim> UserOperationClaims { get; set; } = new HashSet<UserOperationClaim>();
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();


}