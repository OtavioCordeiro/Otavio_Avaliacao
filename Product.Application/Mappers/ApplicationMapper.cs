using MyProduct.Application.ViewModels;
using MyProduct.Domain.Models;

namespace MyProduct.Application.Mappers
{
    public static class ApplicationMapper
    {
        internal static Category ToCategoryEntity(CreateCategoryRequest category)
        {
            if (category == null) return null;

            return new Category() { Situation = category.Situation, Name = category.Name };
        }

        internal static void ToCategoryUpdate(Category existingCategory, UpdateCategoryViewModel category)
        {
            existingCategory.Situation = category.Situation;
            existingCategory.Name = category.Name;
        }

        internal static List<CategoryViewModel> ToCategoryViewModels(List<Category> categoryEntities)
        {
            if (categoryEntities == null || categoryEntities.Count == 0) return new List<CategoryViewModel>();

            List<CategoryViewModel> result = new List<CategoryViewModel>();

            foreach (var entity in categoryEntities)
            {
                var categoryViewModel = ToCategoryViewModels(entity);

                result.Add(categoryViewModel);
            }

            return result;

        }

        internal static CategoryViewModel ToCategoryViewModels(Category entity)
        {
            return new CategoryViewModel()
            {
                Name = entity.Name,
                Situation = entity.Situation,
                Id = entity.Id
            };
        }
    }
}
