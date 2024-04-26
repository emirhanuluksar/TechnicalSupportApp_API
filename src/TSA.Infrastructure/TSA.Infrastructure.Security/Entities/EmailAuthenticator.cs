using TSA.Core.Domain.Entities.Common;

namespace TSA.Infrastructure.Security.Entities;

public class EmailAuthenticator : Entity<Guid>
{
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public string? ActivationKey { get; set; }
    public bool IsActivated { get; set; }
}