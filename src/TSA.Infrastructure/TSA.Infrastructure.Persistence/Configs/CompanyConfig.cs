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
        builder.Property(c => c.LogoUrl).HasColumnName("CompanyLogoUrl");
        builder.Property(c => c.CoverImageUrl).HasColumnName("CompanyCoverImageUrl");
        builder.Property(c => c.Description).HasColumnName("CompanyDescription").IsRequired();
        builder.Property(c => c.PhoneNumber).HasColumnName("CompanyPhoneNumber").IsRequired();
        builder.Property(c => c.Website).HasColumnName("CompanyWebsite").IsRequired();

        builder.Property(c => c.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(c => c.UpdatedAt).HasColumnName("UpdatedAt");
        builder.Property(c => c.DeletedAt).HasColumnName("DeletedAt");

        builder.HasQueryFilter(c => !c.DeletedAt.HasValue);

        builder.HasData
        (
            new Company
            {
                Id = Guid.NewGuid(),
                Name = "Uluksar",
                Email = "test@test.com",
                LogoUrl = "/images/companyLogos/Dgtl.png",
                CoverImageUrl = "/images/companyCoverImages/company1.jpg",
                Address = "Kavacık Mahallesi, Fatih Sultan Mehmet Cd. No:1, 34805 Beykoz/İstanbul",
                Description = "Uluksar is a company that provides software solutions.",
                PhoneNumber = "+1234567890",
                Website = "www.uluksar.com",
            },
            new Company
            {
                Id = Guid.NewGuid(),
                Name = "Digitalhat",
                Email = "dgtalhat@dgtalhat.com",
                LogoUrl = "/images/companyLogos/Dgtl.png",
                CoverImageUrl = "/images/companyCoverImages/company2.jpeg",
                Address = "Kavacık Mahallesi, Fatih Sultan Mehmet Cd. No:1, 34805 Beykoz/İstanbul",
                Description = "Digitalhat is a company that provides software solutions.",
                PhoneNumber = "+1234567890",
                Website = "www.digitalhat.com",
            },
            new Company
            {
                Id = Guid.NewGuid(),
                Name = "ULUARS HOLDING",
                Email = "uluars@uluars.com",
                LogoUrl = "/images/companyLogos/Dgtl.png",
                CoverImageUrl = "/images/companyCoverImages/company3.jpg",
                Address = "SAMSUNG-Torium AVM Saadetdere Mh.E-5 Üzeri, Haramidere Cd., 34903 Avcılar/İstanbul",
                Description = "ULUARS HOLDING is a company that provides software solutions.",
                PhoneNumber = "+1234567890",
                Website = "www.uluars.com",
            },
            new Company
            {
                Id = Guid.NewGuid(),
                Name = "Justwork",
                Email = "justwork@justwork.com",
                LogoUrl = "/images/companyLogos/Dgtl.png",
                CoverImageUrl = "/images/companyCoverImages/company3.jpg",
                Address = "Meydan İstanbul AVM, Balkan Cd. No:62, 34770 Ümraniye/İstanbul",
                Description = "Justwork is a company that provides software solutions.",
                PhoneNumber = "+1234567890",
                Website = "www.justwork.com",
            }
        );

    }
}