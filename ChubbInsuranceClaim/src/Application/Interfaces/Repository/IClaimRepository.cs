using ChubbInsuranceClaim.src.Domain.Entity;

namespace ChubbInsuranceClaim.src.Application.Interfaces.Repository
{
    public interface IClaimRepository
    {
        Task<InsuranceClaim?> GetByIdAsync(int id);
        Task<InsuranceClaim?> GetByClaimNumberAsync(string claimNumber);
        Task<List<InsuranceClaim>> GetAllAsync();
        Task<List<InsuranceClaim>> GetClaimsByCustomerAsync(int customerId);
        Task<List<InsuranceClaim>> GetAssignedClaimsAsync(int officerId);
        Task<List<InsuranceClaim>> GetPendingClaimsAsync();
        Task AddAsync(InsuranceClaim claim);
        void Update(InsuranceClaim claim);
        void Delete(InsuranceClaim claim);
    }
}
