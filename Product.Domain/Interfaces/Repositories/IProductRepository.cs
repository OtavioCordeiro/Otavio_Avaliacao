using MyProduct.Domain.Models;

namespace MyProduct.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>, IDisposable
    {
    }
}
