using MyProduct.Application.Mappers;
using MyProduct.Application.Models;
using MyProduct.Application.Services.Interfaces;
using MyProduct.Application.ViewModels;
using MyProduct.Domain.Interfaces.Repositories;
using MyProduct.Domain.Models;

namespace MyProduct.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository repository, ICategoryRepository categoryRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ProductViewModel> CreateAsync(CreateProductRequest request)
        {
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);

            if (category == null)
                throw new ArgumentException("Categoria não encontrada");

            Product productEntity = ApplicationMapper.ToProductEntity(request);
            productEntity.Category = category;

            await _repository.CreateAsync(productEntity);

            return ApplicationMapper.ToProductViewModel(productEntity);
        }

        public async Task<List<ProductViewModel>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return ApplicationMapper.ToProductViewModel(entities);
        }

        public async Task<ProductViewModel> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return ApplicationMapper.ToProductViewModel(entity);

        }

        public async Task<List<ProductViewModel>> SearchAsync(ProductFilter filter)
        {
            var categories = await _repository.GetByFilterAsync(c =>
            (string.IsNullOrEmpty(filter.Description) || c.Name.Contains(filter.Description)) &&
            (filter.Situation == null || c.Situation.Equals(filter.Situation.Value)) &&
            (filter.Category == null || c.Category.Name.Contains(filter.Category)));

            return ApplicationMapper.ToProductViewModel(categories);
        }

        public async Task<ProductViewModel> UpdateAsync(int id, UpdateProductViewModel request)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null) return null;

            ApplicationMapper.ToProductUpdate(entity, request);

            await _repository.UpdateAsync(entity);

            return ApplicationMapper.ToProductViewModel(entity);
        }
    }
}
