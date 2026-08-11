using ChubbInsuranceClaim.src.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChubbInsuranceClaim.src.Infrastructure.Configurations
{
    public class ClaimConfiguration : IEntityTypeConfiguration<InsuranceClaim>
    {
        public void Configure(EntityTypeBuilder<InsuranceClaim> builder)
        {
            builder.ToTable("Claims");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ClaimNumber)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(x => x.ClaimNumber)
                .IsUnique();

            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            builder.Property(x => x.ClaimAmount)
                .HasPrecision(18, 2);

            builder.Property(x => x.Status)
                .HasConversion<string>();

            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(x => x.User)
                .WithMany(x => x.Claims)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Incident)
                .WithMany(x => x.Claims)
                .HasForeignKey(x => x.IncidentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
