using System.Linq.Expressions;

namespace MyProduct.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        List<T> GetByFilter(Expression<Func<T, bool>> filter);
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
    }
}
