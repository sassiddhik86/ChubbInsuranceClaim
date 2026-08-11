using ChubbInsuranceClaim.src.Application.Interfaces.Repository;
using ChubbInsuranceClaim.src.Infrastructure.Context;

namespace ChubbInsuranceClaim.src.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(
            ApplicationDbContext context,
            IUserRepository users,
            IRoleRepository roles,
            IIncidentRepository incidents,
            IClaimRepository claims,
            IClaimAssignmentRepository claimAssignments,
            IClaimDocumentRepository claimDocuments)
        {
            _context = context;
            Users = users;
            Roles = roles;
            Incidents = incidents;
            Claims = claims;
            ClaimAssignments = claimAssignments;
            ClaimDocuments = claimDocuments;
        }

        public IUserRepository Users { get; }
        public IRoleRepository Roles { get; }
        public IIncidentRepository Incidents { get; }
        public IClaimRepository Claims { get; }
        public IClaimAssignmentRepository ClaimAssignments { get; }
        public IClaimDocumentRepository ClaimDocuments { get; }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
