using MyProduct.Application.Models;
using MyProduct.Application.ViewModels;

namespace MyProduct.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetAllAsync();
        Task<ProductViewModel> GetByIdAsync(int id);
        Task<ProductViewModel> CreateAsync(CreateProductRequest request);
        Task<ProductViewModel> UpdateAsync(int id, UpdateProductViewModel request);
        Task<List<ProductViewModel>> SearchAsync(ProductFilter filter);
    }
}
