using ChubbInsuranceClaim.src.Application.DTO.Users;
using ChubbInsuranceClaim.src.Domain.Entity;

namespace ChubbInsuranceClaim.src.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<BusinessUser?> GetByIdAsync(int id);

        Task<BusinessUser?> GetByEmailAsync(string email);

        Task<BusinessUser?> GetByEmployeeNumberAsync(string employeeNumber);

        Task<List<BusinessUser>> GetAllAsync();

        Task AddAsync(BusinessUser user);

        void Update(BusinessUser user);

        void Delete(BusinessUser user);
    }
}
