using MyProduct.Application.ViewModels;

namespace MyProduct.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryViewModel> GetAll();
        CategoryViewModel GetById(int id);
        CategoryViewModel Create(CreateCategoryRequest category);
        void Update(UpdateCategoryViewModel category);
    }
}
