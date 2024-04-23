
namespace TSA.Core.Domain.Entities.Common;

public class Entity<TId> : IEntityTimestamps
{
    public TId Id { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
