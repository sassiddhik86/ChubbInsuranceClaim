using ChubbInsuranceClaim.src.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChubbInsuranceClaim.src.Infrastructure.Configurations
{
    public class ClaimStatusHistoryConfiguration : IEntityTypeConfiguration<ClaimStatusHistory>
    {
        public void Configure(EntityTypeBuilder<ClaimStatusHistory> builder)
        {
            builder.ToTable("ClaimStatusHistories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Status)
                .HasConversion<string>();

            builder.Property(x => x.Remarks)
                .HasMaxLength(1000);

            builder.HasOne(x => x.Claim)
                .WithMany(x => x.StatusHistories)
                .HasForeignKey(x => x.ClaimId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
