using System.Linq.Expressions;

namespace MyProduct.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetByFilterAsync(Expression<Func<T, bool>> filter);
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
