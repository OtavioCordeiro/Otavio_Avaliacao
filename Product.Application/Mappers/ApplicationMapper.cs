﻿using MyProduct.Application.ViewModels;
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
        internal static void ToCategoryUpdate(Category entity, UpdateCategoryViewModel request)
        {
            entity.Situation = request.Situation != null ? request.Situation.Value : entity.Situation;
            entity.Name = request.Name != null ? request.Name : entity.Name;
        }
        internal static List<CategoryViewModel> ToCategoryViewModel(List<Category> entities)
        {
            if (entities == null || entities.Count == 0) return new List<CategoryViewModel>();

            List<CategoryViewModel> result = new List<CategoryViewModel>();

            foreach (var entity in entities)
            {
                var categoryViewModel = ToCategoryViewModel(entity);

                result.Add(categoryViewModel);
            }

            return result;

        }
        internal static CategoryViewModel ToCategoryViewModel(Category entity)
        {
            if (entity == null) return null;

            return new CategoryViewModel()
            {
                Name = entity.Name,
                Situation = entity.Situation,
                Id = entity.Id
            };
        }

        internal static Product ToProductEntity(CreateProductRequest request)
        {
            return new Product
            {
                CategoryId = request.CategoryId,
                Description = request.Description,
                Name = request.Name,
                Price = request.Price,
                Situation = request.Situation
            };
        }
        internal static void ToProductUpdate(Product entity, UpdateProductViewModel product)
        {
            entity.CategoryId = product.CategoryId != null ? product.CategoryId.Value : entity.CategoryId;
            entity.Price = product.Price != null ? product.Price.Value : entity.Price;
            entity.Name = product.Name != null ? product.Name : entity.Name;
            entity.Description = product.Description != null ? product.Description : entity.Description;
            entity.Situation = product.Situation != null ? product.Situation.Value : entity.Situation;
        }
        internal static List<ProductViewModel> ToProductViewModel(List<Product> entities)
        {
            if (entities == null || entities.Count == 0) return new List<ProductViewModel>();

            var result = new List<ProductViewModel>();

            foreach (var entity in entities)
            {
                var view = ToProductViewModel(entity);

                result.Add(view);
            }

            return result;
        }
        internal static ProductViewModel ToProductViewModel(Product entity)
        {
            if (entity == null) return null;

            return new ProductViewModel
            {
                Category = ToCategoryViewModel(entity.Category),
                Description = entity.Description,
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Situation = entity.Situation
            };
        }
    }
}
