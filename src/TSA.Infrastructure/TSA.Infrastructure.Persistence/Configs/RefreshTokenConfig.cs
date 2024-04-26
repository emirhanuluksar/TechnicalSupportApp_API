using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSA.Infrastructure.Security.Entities;

namespace TSA.Infrastructure.Persistence.Configs;

public class RefreshTokenConfig : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshTokens").HasKey(rt => rt.Id);

        builder.Property(rt => rt.Id).HasColumnName("RefreshTokenId");
        builder.Property(rt => rt.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(rt => rt.Token).HasColumnName("Token").IsRequired();
        builder.Property(rt => rt.ExpirationDate).HasColumnName("Expiration").IsRequired();
        builder.Property(rt => rt.CreatedByIp).HasColumnName("CreatedByIp").IsRequired();
        builder.Property(rt => rt.RevokedDate).HasColumnName("RevokedDate");
        builder.Property(rt => rt.RevokedByIp).HasColumnName("RevokedByIp");
        builder.Property(rt => rt.ReplacedByToken).HasColumnName("ReplacedByToken");
        builder.Property(rt => rt.ReasonRevoked).HasColumnName("ReasonRevoked");

        builder.Property(rt => rt.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(rt => rt.UpdatedAt).HasColumnName("UpdatedAt");
        builder.Property(rt => rt.DeletedAt).HasColumnName("DeletedAt");

        builder.HasQueryFilter(rt => !rt.DeletedAt.HasValue);
    }
}
