using ChubbInsuranceClaim.src.Application.Interfaces.Repository;
using ChubbInsuranceClaim.src.Domain.Entity;
using ChubbInsuranceClaim.src.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ChubbInsuranceClaim.src.Infrastructure.Repositories
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly ApplicationDbContext _context;

        public IncidentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Incident incident)
        {
            await _context.Incidents.AddAsync(incident);
        }

        public void Delete(Incident incident)
        {
            _context.Incidents.Remove(incident);
        }

        public Task<List<Incident>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Incident?> GetByIdAsync(int id)
        {
            return await _context.Incidents
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Incident>> GetMyIncidentsAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public void Update(Incident incident)
        {
            _context.Incidents.Update(incident);
        }
    }
}
