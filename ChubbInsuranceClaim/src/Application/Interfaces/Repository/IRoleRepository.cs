using ChubbInsuranceClaim.src.Domain.Entity;
using System.Data;

namespace ChubbInsuranceClaim.src.Application.Interfaces.Repository
{
    public interface IRoleRepository
    {
        Task<BusinessRole?> GetByIdAsync(int id);
        Task<List<BusinessRole>> GetAllAsync();
    }
}
