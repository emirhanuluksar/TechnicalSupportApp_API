using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSA.Infrastructure.Security.Entities;

namespace TSA.Infrastructure.Persistence.Configs;

public class OperationClaimConfig : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("OperationClaimId");
        builder.Property(oc => oc.OperationClaimName).HasColumnName("OperationClaimName").IsRequired();

        builder.Property(oc => oc.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(oc => oc.UpdatedAt).HasColumnName("UpdatedAt");
        builder.Property(oc => oc.DeletedAt).HasColumnName("DeletedAt");

        builder.HasMany(oc => oc.UserOperationClaims)
            .WithOne(uoc => uoc.OperationClaim)
            .HasForeignKey(uoc => uoc.OperationClaimId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(oc => !oc.DeletedAt.HasValue);

        builder.HasData
        (
            new OperationClaim
            {
                Id = 1,
                OperationClaimName = "Admin"
            },
            new OperationClaim
            {
                Id = 2,
                OperationClaimName = "User"
            }
        );
    }
}