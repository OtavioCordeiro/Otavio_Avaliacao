using Microsoft.EntityFrameworkCore;
using MyProduct.Domain.Interfaces.Repositories;
using MyProduct.Domain.Models;
using MyProduct.Infrastructure.Data;
using System.Linq.Expressions;

namespace MyProduct.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
