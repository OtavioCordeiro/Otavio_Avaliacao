using MyProduct.Application.ViewModels;

namespace MyProduct.Application.Services.Interfaces
{
    public interface IProductService
    {
        List<ProductViewModel> GetAll();
        List<ProductViewModel> GetByCategoryId(int categoryId);
        ProductViewModel GetById(int id);
        void Create(CreateProductRequest product);
        void Update(UpdateProductViewModel product);
    }
}
