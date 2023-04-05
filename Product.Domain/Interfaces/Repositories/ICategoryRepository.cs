using MyProduct.Domain.Models;

namespace MyProduct.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository : IRepository<Category>, IDisposable
    {
    }
}
