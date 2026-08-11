using ChubbInsuranceClaim.src.Application.Interfaces.Repository;
using ChubbInsuranceClaim.src.Domain.Entity;
using ChubbInsuranceClaim.src.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ChubbInsuranceClaim.src.Infrastructure.Repositories
{
    public class ClaimAssignmentRepository : IClaimAssignmentRepository
    {
        private readonly ApplicationDbContext _context;

        public ClaimAssignmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ClaimAssignment assignment)
        {
            await _context.ClaimAssignments.AddAsync(assignment);
        }

        public async Task<List<ClaimAssignment>> GetAssignmentsAsync(int claimId)
        {
            return await _context.ClaimAssignments
                .Where(x => x.ClaimId == claimId)
                .Include(x => x.Officer)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
