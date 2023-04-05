using MyProduct.Domain.Models;
using MyProduct.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using MyProduct.Infrastructure.Data;

namespace MyProduct.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async void Dispose()
        {
            await _context.DisposeAsync();
            GC.SuppressFinalize(this);
        }
    }
}
