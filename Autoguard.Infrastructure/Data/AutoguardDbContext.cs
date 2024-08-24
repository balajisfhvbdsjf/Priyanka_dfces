using Autoguard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Autoguard.Infrastructure.Data
{
    public class AutoguardDbContext : DbContext
    {
        private static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddSerilog();
        });

        public AutoguardDbContext(DbContextOptions<AutoguardDbContext> options) : base(options)
        {
        }

        // DbSets for entities
        public DbSet<Business> Businesses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLoggerFactory(loggerFactory)
                    .EnableSensitiveDataLogging(); // Logging sensitive data for development purposes
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Business Entity Configuration
            modelBuilder.Entity<Business>(entity =>
            {
                entity.HasKey(b => b.BusinessId); // Primary Key
                entity.Property(b => b.BusinessName)
                    .IsRequired()
                    .HasMaxLength(255); // Business Name Required and MaxLength
                entity.Property(b => b.RegNumber)
                    .IsRequired()
                    .HasMaxLength(50); // Registration Number
                entity.Property(b => b.BusinessEmail)
                    .IsRequired()
                    .HasMaxLength(255); // Business Email
                entity.Property(b => b.BusinessContactNumber)
                    .IsRequired()
                    .HasMaxLength(20); // Business Contact Number

                entity.Property(b => b.Suburb)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(b => b.City)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(b => b.Province)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(b => b.PostalCode)
                    .IsRequired();
                entity.Property(b => b.GeoLocation)
                    .HasMaxLength(255); // GeoLocation

                entity.Property(b => b.TaxNumber)
                    .IsRequired()
                    .HasColumnType("BIGINT"); // Tax Number as bigint
                entity.Property(b => b.PayeNumber)
                    .IsRequired()
                    .HasMaxLength(10); // PAYE Number
                entity.Property(b => b.VatNumber)
                    .IsRequired()
                    .HasMaxLength(10); // VAT Number

                // File paths
                entity.Property(b => b.CipcFilePath)
                    .HasMaxLength(500); // File path for CIPC
                entity.Property(b => b.PsiraDocumentationFilePath)
                    .HasMaxLength(500); // File path for Psira
                entity.Property(b => b.BusinessLogoImagePath)
                    .HasMaxLength(500); // File path for Business Logo
                entity.Property(b => b.OperationalCountry)
                    .IsRequired()
                    .HasMaxLength(255); // Operational Country
                entity.Property(b => b.NumberOfPeople)
                    .HasMaxLength(255); // Number of People
            });

            // Add configurations for other entities here if needed
        }
    }
}
