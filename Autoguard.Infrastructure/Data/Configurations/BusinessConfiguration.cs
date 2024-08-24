using Autoguard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autoguard.Infrastructure.Data.Configurations
{
    public class BusinessConfiguration : IEntityTypeConfiguration<Business>
    {
        public void Configure(EntityTypeBuilder<Business> builder)
        {
            builder.HasKey(b => b.BusinessId);
            builder.Property(b => b.BusinessName).IsRequired().HasMaxLength(200);
            builder.Property(b => b.RegNumber).IsRequired().HasMaxLength(20);
            builder.Property(b => b.BusinessEmail).IsRequired().HasMaxLength(100);
            builder.Property(b => b.BusinessContactNumber).IsRequired().HasMaxLength(15);
            builder.Property(b => b.PostalCode).IsRequired();
            builder.Property(b => b.GeoLocation).IsRequired();
            builder.Property(b => b.TaxNumber).IsRequired();
            builder.Property(b => b.CipcFilePath).IsRequired();
            builder.Property(b => b.PsiraDocumentationFilePath).IsRequired();
            builder.Property(b => b.PayeNumber).IsRequired().HasMaxLength(10);
            builder.Property(b => b.VatNumber).IsRequired().HasMaxLength(10);
            builder.Property(b => b.OperationalCountry).IsRequired().HasMaxLength(50);
            builder.Property(b => b.BusinessLogoImagePath).IsRequired();
            builder.Property(b => b.NumberOfPeople).IsRequired();
        }
    }
}
