using ChubbInsuranceClaim.src.Application.Interfaces.Repository;
using ChubbInsuranceClaim.src.Domain.Entity;
using ChubbInsuranceClaim.src.Domain.Enums;
using ChubbInsuranceClaim.src.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ChubbInsuranceClaim.src.Infrastructure.Repositories
{
    public class ClaimRepository : IClaimRepository
    {
        private readonly ApplicationDbContext _context;

        public ClaimRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(InsuranceClaim claim)
        {
            await _context.Claims.AddAsync(claim);
        }

        public void Delete(InsuranceClaim claim)
        {
            _context.Claims.Remove(claim);
        }

        public async Task<List<InsuranceClaim>> GetAllAsync()
        {
            return await _context.Claims
                .Include(x => x.User)
                .Include(x => x.Incident)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<InsuranceClaim?> GetByIdAsync(int id)
        {
            return await _context.Claims
                .Include(x => x.User)
                .Include(x => x.Incident)
                .Include(x => x.Documents)
                .Include(x => x.StatusHistories)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<InsuranceClaim?> GetByClaimNumberAsync(string claimNumber)
        {
            return await _context.Claims
                .FirstOrDefaultAsync(x => x.ClaimNumber == claimNumber);
        }

        public async Task<List<InsuranceClaim>> GetClaimsByCustomerAsync(int customerId)
        {
            return await _context.Claims
                .Where(x => x.UserId == customerId)
                .OrderByDescending(x => x.CreatedDate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<InsuranceClaim>> GetAssignedClaimsAsync(int officerId)
        {
            return await _context.Claims
                .Include(x => x.Assignments)
                .Where(x => x.Assignments.Any(a => a.OfficerId == officerId))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<InsuranceClaim>> GetPendingClaimsAsync()
        {
            return await _context.Claims
                .Where(x =>
                    x.Status == ClaimStatus.Submitted ||
                    x.Status == ClaimStatus.Assigned ||
                    x.Status == ClaimStatus.UnderReview)
                .AsNoTracking()
                .ToListAsync();
        }

        public void Update(InsuranceClaim claim)
        {
            _context.Claims.Update(claim);
        }
    }
}
