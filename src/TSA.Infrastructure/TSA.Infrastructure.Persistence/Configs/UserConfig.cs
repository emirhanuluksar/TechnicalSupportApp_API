using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSA.Infrastructure.Security.Entities;

namespace TSA.Infrastructure.Persistence.Configs;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(u => u.Id);

        builder.Property(u => u.Id).HasColumnName("UserId");
        builder.Property(u => u.Username).HasColumnName("Username").IsRequired();
        builder.Property(u => u.NormalizedUserName).HasColumnName("NormalizedUsername").IsRequired();
        builder.Property(u => u.Email).HasColumnName("UserEmail").IsRequired();
        builder.Property(u => u.NormalizedEmail).HasColumnName("NormalizedUserEmail").IsRequired();
        builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();
        builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
        builder.Property(u => u.IsEmailVerified).HasColumnName("IsEmailVerified").IsRequired();
        builder.Property(u => u.Status).HasColumnName("Status").IsRequired();
        builder.Property(u => u.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(u => u.UpdatedAt).HasColumnName("UpdatedAt");
        builder.Property(u => u.DeletedAt).HasColumnName("DeletedAt");

        builder.HasQueryFilter(u => !u.DeletedAt.HasValue);

        builder.HasMany(u => u.UserOperationClaims)
            .WithOne(uoc => uoc.User)
            .HasForeignKey(uoc => uoc.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.RefreshTokens)
            .WithOne(rt => rt.User)
            .HasForeignKey(rt => rt.UserId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
