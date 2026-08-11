using ChubbInsuranceClaim.src.Application.Interfaces.Repository;
using ChubbInsuranceClaim.src.Domain.Entity;
using ChubbInsuranceClaim.src.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ChubbInsuranceClaim.src.Infrastructure.Repositories
{
    public class ClaimDocumentRepository : IClaimDocumentRepository
    {
        private readonly ApplicationDbContext _context;

        public ClaimDocumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ClaimDocument document)
        {
            await _context.ClaimDocuments.AddAsync(document);
        }

        public void Delete(ClaimDocument document)
        {
            _context.ClaimDocuments.Remove(document);
        }

        public async Task<List<ClaimDocument>> GetDocumentsAsync(int claimId)
        {
            return await _context.ClaimDocuments
                .Where(x => x.ClaimId == claimId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
