using ChubbInsuranceClaim.src.Application.Interfaces.Repository;
using ChubbInsuranceClaim.src.Domain.Entity;
using ChubbInsuranceClaim.src.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ChubbInsuranceClaim.src.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<BusinessRole>> GetAllAsync()
        {
            return await _context.Roles
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<BusinessRole?> GetByIdAsync(int id)
        {
            return await _context.Roles
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
