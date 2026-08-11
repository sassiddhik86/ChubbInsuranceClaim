using ChubbInsuranceClaim.src.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace ChubbInsuranceClaim.src.Infrastructure.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<BusinessRole>
    {
        public void Configure(EntityTypeBuilder<BusinessRole> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(200);

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.HasData(
                new BusinessRole { Id = 1, Name = "Admin", Description = "System Administrator" },
                new BusinessRole { Id = 2, Name = "ClaimOfficer", Description = "Claims Officer" },
                new BusinessRole { Id = 3, Name = "Supervisor", Description = "Claims Supervisor" },
                new BusinessRole { Id = 4, Name = "Customer", Description = "Customer" }
            );
        }
    }
}
