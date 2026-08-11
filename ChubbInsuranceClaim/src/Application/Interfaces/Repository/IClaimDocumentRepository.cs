using ChubbInsuranceClaim.src.Domain.Entity;

namespace ChubbInsuranceClaim.src.Application.Interfaces.Repository
{
    public interface IClaimDocumentRepository
    {
        Task AddAsync(ClaimDocument document);

        Task<List<ClaimDocument>> GetDocumentsAsync(int claimId);

        void Delete(ClaimDocument document);
    }
}
