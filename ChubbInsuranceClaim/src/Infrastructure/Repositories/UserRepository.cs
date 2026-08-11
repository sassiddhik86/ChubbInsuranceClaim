using ChubbInsuranceClaim.src.Application.Interfaces.Repository;
using ChubbInsuranceClaim.src.Domain.Entity;
using ChubbInsuranceClaim.src.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ChubbInsuranceClaim.src.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(BusinessUser user)
        {
            await _context.Users.AddAsync(user);
        }

        public void Delete(BusinessUser user)
        {
            _context.Users.Remove(user);
        }

        public async Task<List<BusinessUser>> GetAllAsync()
        {
            return await _context.Users
                .Include(x => x.Role)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<BusinessUser?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<BusinessUser?> GetByEmployeeNumberAsync(string employeeNumber)
        {
            return await _context.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.EmployeeNumber == employeeNumber);
        }

        public async Task<BusinessUser?> GetByIdAsync(int id)
        {
            return await _context.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(BusinessUser user)
        {
            _context.Users.Update(user);
        }
    }
}
