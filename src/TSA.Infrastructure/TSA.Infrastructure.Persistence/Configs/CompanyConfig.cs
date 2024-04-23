using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSA.Core.Domain.Entities;

namespace TSA.Infrastructure.Persistence.Configs;

public class CompanyConfig : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("CompanyId");
        builder.Property(c => c.Name).HasColumnName("CompanyName").IsRequired();
        builder.Property(c => c.Email).HasColumnName("CompanyEmail").IsRequired();
        builder.Property(c => c.Description).HasColumnName("CompanyDescription").IsRequired();
        builder.Property(c => c.PhoneNumber).HasColumnName("CompanyPhoneNumber").IsRequired();
        builder.Property(c => c.Website).HasColumnName("CompanyWebsite").IsRequired();

        builder.HasQueryFilter(c => !c.DeletedAt.HasValue);

        builder.HasData
        (
            new Company
            {
                Id = Guid.NewGuid(),
                Name = "Uluksar",
                Email = "test@test.com",
                Description = "Uluksar is a company that provides software solutions.",
                PhoneNumber = "+1234567890",
                Website = "www.uluksar.com",
            },
            new Company
            {
                Id = Guid.NewGuid(),
                Name = "Digitalhat",
                Email = "dgtalhat@dgtalhat.com",
                Description = "Digitalhat is a company that provides software solutions.",
                PhoneNumber = "+1234567890",
                Website = "www.digitalhat.com",
            },
            new Company
            {
                Id = Guid.NewGuid(),
                Name = "ULUARS HOLDING",
                Email = "uluars@uluars.com",
                Description = "ULUARS HOLDING is a company that provides software solutions.",
                PhoneNumber = "+1234567890",
                Website = "www.uluars.com",
            }
        );

    }
}