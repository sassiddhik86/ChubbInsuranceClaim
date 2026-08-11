using System.Linq.Expressions;

namespace ChubbInsuranceClaim.src.Application.Interfaces.Repository
{
    public interface IGenericRepository<T>
        where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByIdAsync(Guid id);

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        void Update(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}
