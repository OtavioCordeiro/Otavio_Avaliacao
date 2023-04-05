using MyProduct.Application.Mappers;
using MyProduct.Application.Models;
using MyProduct.Application.Services.Interfaces;
using MyProduct.Application.ViewModels;
using MyProduct.Domain.Interfaces.Repositories;
using MyProduct.Domain.Models;

namespace MyProduct.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CategoryViewModel> CreateAsync(CreateCategoryRequest category)
        {
            Category categoryEntity = ApplicationMapper.ToCategoryEntity(category);
            await _repository.CreateAsync(categoryEntity);

            return ApplicationMapper.ToCategoryViewModel(categoryEntity);
        }

        public async Task<List<CategoryViewModel>> GetAllAsync()
        {
            var categoryEntities = await _repository.GetAllAsync();
            List<CategoryViewModel> categoryViewModels = ApplicationMapper.ToCategoryViewModel(categoryEntities);
            return categoryViewModels;
        }

        public async Task<CategoryViewModel> GetByIdAsync(int id)
        {
            var categoryEntity = await _repository.GetByIdAsync(id);
            var category = ApplicationMapper.ToCategoryViewModel(categoryEntity);
            return category;
        }

        public async Task<CategoryViewModel> UpdateAsync(int id, UpdateCategoryViewModel category)
        {
            var existingCategory = await _repository.GetByIdAsync(id);

            if (existingCategory == null) return null;

            ApplicationMapper.ToCategoryUpdate(existingCategory, category);

            await _repository.UpdateAsync(existingCategory);

            return ApplicationMapper.ToCategoryViewModel(existingCategory);
        }

        public async Task<List<CategoryViewModel>> SearchAsync(CategoryFilter filter)
        {
            var categories = await _repository.GetByFilterAsync(c =>
            (string.IsNullOrEmpty(filter.Name) || c.Name.Contains(filter.Name)) &&
            (filter.Situation == null || c.Situation.Equals(filter.Situation.Value)));

            var categoriesViewModel = ApplicationMapper.ToCategoryViewModel(categories);

            return categoriesViewModel;
        }
    }
}
