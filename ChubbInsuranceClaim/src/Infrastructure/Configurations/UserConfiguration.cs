using ChubbInsuranceClaim.src.Application.DTO.Users;
using ChubbInsuranceClaim.src.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChubbInsuranceClaim.src.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<BusinessUser>
    {
        public void Configure(EntityTypeBuilder<BusinessUser> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.EmployeeNumber)
                .HasMaxLength(20);

            builder.Property(x => x.FullName)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.PasswordHash)
                .HasMaxLength(500)
                .IsRequired();

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.HasIndex(x => x.EmployeeNumber)
                .IsUnique();

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
