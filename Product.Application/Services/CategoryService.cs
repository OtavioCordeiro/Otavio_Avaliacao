using MyProduct.Application.Mappers;
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

        public CategoryViewModel Create(CreateCategoryRequest category)
        {
            Category categoryEntity = ApplicationMapper.ToCategoryEntity(category);
            _repository.Create(categoryEntity);

            return ApplicationMapper.ToCategoryViewModels(categoryEntity);
        }

        public List<CategoryViewModel> GetAll()
        {
            var categoryEntities = _repository.GetAll();
            List<CategoryViewModel> categoryViewModels = ApplicationMapper.ToCategoryViewModels(categoryEntities);
            return categoryViewModels;
        }

        public CategoryViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UpdateCategoryViewModel category)
        {
            throw new NotImplementedException();
        }
    }
}
