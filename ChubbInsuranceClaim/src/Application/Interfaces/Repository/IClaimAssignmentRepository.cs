using ChubbInsuranceClaim.src.Domain.Entity;

namespace ChubbInsuranceClaim.src.Application.Interfaces.Repository
{
    public interface IClaimAssignmentRepository
    {
        Task AddAsync(ClaimAssignment assignment);
        Task<List<ClaimAssignment>> GetAssignmentsAsync(int claimId);
    }
}
