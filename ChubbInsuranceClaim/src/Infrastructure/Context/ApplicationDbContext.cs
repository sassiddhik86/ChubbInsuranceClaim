using ChubbInsuranceClaim.src.Application.DTO.Users;
using ChubbInsuranceClaim.src.Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ChubbInsuranceClaim.src.Infrastructure.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BusinessRole> Roles => Set<BusinessRole>();

        public DbSet<BusinessUser> Users => Set<BusinessUser>();

        public DbSet<Incident> Incidents => Set<Incident>();

        public DbSet<InsuranceClaim> Claims => Set<InsuranceClaim>();

        public DbSet<ClaimAssignment> ClaimAssignments => Set<ClaimAssignment>();

        public DbSet<ClaimDocument> ClaimDocuments => Set<ClaimDocument>();

        public DbSet<ClaimStatusHistory> ClaimStatusHistories => Set<ClaimStatusHistory>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
