using ChubbInsuranceClaim.src.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChubbInsuranceClaim.src.Infrastructure.Configurations
{
    public class IncidentConfiguration : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.ToTable("Incidents");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Location)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(x => x.PoliceReportNumber)
                .HasMaxLength(100);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("GETUTCDATE()");

            //builder.HasOne(x => x.CreatedByUser)
            //        .WithMany()
            //        .HasForeignKey(x => x.CreatedByUserId)
            //        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
