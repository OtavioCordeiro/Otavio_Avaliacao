using MyProduct.Application.Models;
using MyProduct.Application.ViewModels;

namespace MyProduct.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAllAsync();
        Task<CategoryViewModel> GetByIdAsync(int id);
        Task<CategoryViewModel> CreateAsync(CreateCategoryRequest category);
        Task<CategoryViewModel> UpdateAsync(int id, UpdateCategoryViewModel category);
        Task<List<CategoryViewModel>> SearchAsync(CategoryFilter filter);
    }
}
