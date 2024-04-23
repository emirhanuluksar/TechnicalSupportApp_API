using TSA.Core.Domain.Entities.Common;

namespace TSA.Core.Domain.Entities;

public class Company : Entity<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    // public string Logo { get; set; } = string.Empty;
    // public string CoverImage { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;

}