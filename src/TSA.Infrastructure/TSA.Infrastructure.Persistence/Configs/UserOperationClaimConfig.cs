using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSA.Infrastructure.Security.Entities;

namespace TSA.Infrastructure.Persistence.Configs;

public class UserOperationClaimConfig : IEntityTypeConfiguration<UserOperationClaim>
{
    public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {
        builder.ToTable("UserOperationClaims").HasKey(uoc => uoc.Id);

        builder.Property(uoc => uoc.Id).HasColumnName("UserOperationClaimId");
        builder.Property(uoc => uoc.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(uoc => uoc.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();

        builder.Property(uoc => uoc.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(uoc => uoc.UpdatedAt).HasColumnName("UpdatedAt");
        builder.Property(uoc => uoc.DeletedAt).HasColumnName("DeletedAt");

        builder.HasQueryFilter(uoc => !uoc.User.DeletedAt.HasValue);
    }
}