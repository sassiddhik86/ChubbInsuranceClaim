using ChubbInsuranceClaim.src.Domain.Entity;

namespace ChubbInsuranceClaim.src.Application.Interfaces.Repository
{
    public interface IIncidentRepository
    {
        Task<Incident?> GetByIdAsync(int id);
        Task<List<Incident>> GetAllAsync();
        Task AddAsync(Incident incident);
        void Update(Incident incident);
        void Delete(Incident incident);
        Task<List<Incident>> GetMyIncidentsAsync(int userId);
    }
}
