using MyProduct.Application.Services.Interfaces;
using MyProduct.Application.ViewModels;
using MyProduct.Domain.Interfaces.Repositories;
using MyProduct.Domain.Models;

namespace MyProduct.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public void Create(CreateProductRequest product)
        {
            throw new NotImplementedException();
        }

        public List<ProductViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<ProductViewModel> GetByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public ProductViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UpdateProductViewModel product)
        {
            throw new NotImplementedException();
        }
    }
}
