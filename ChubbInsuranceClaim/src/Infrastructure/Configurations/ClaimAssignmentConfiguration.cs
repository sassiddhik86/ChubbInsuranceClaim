using ChubbInsuranceClaim.src.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChubbInsuranceClaim.src.Infrastructure.Configurations
{
    public class ClaimAssignmentConfiguration : IEntityTypeConfiguration<ClaimAssignment>
    {
        public void Configure(EntityTypeBuilder<ClaimAssignment> builder)
        {
            builder.ToTable("ClaimAssignments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.AssignedDate)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(x => x.Claim)
                .WithMany(x => x.Assignments)
                .HasForeignKey(x => x.ClaimId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Officer)
                .WithMany(x => x.AssignedClaims)
                .HasForeignKey(x => x.OfficerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
