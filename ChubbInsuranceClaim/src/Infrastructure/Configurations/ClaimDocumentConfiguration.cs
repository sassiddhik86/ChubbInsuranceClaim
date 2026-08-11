using ChubbInsuranceClaim.src.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChubbInsuranceClaim.src.Infrastructure.Configurations
{
    public class ClaimDocumentConfiguration : IEntityTypeConfiguration<ClaimDocument>
    {
        public void Configure(EntityTypeBuilder<ClaimDocument> builder)
        {
            builder.ToTable("ClaimDocuments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FileName)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.FilePath)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.ContentType)
                .HasMaxLength(100);

            builder.HasOne(x => x.Claim)
                .WithMany(x => x.Documents)
                .HasForeignKey(x => x.ClaimId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
