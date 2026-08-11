using ChubbInsuranceClaim.src.Domain.Entity;

namespace ChubbInsuranceClaim.src.Application.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IIncidentRepository Incidents { get; }
        IClaimRepository Claims { get; }
        IClaimAssignmentRepository ClaimAssignments { get; }
        IClaimDocumentRepository ClaimDocuments { get; }
        //IClaimStatusHistoryRepository ClaimStatusHistories { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
