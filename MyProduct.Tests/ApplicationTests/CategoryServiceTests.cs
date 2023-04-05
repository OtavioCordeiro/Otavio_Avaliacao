using AutoFixture;
using FluentAssertions;
using MyProduct.Application.Services;
using MyProduct.Domain.Interfaces.Repositories;
using MyProduct.Domain.Models;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProduct.Tests.ApplicationTests
{
    public class CategoryServiceTests
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly Fixture _fixture;
        private readonly CategoryService _sut;

        public CategoryServiceTests()
        {
            _categoryRepository = Substitute.For<ICategoryRepository>();
            _fixture = new Fixture();
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _sut = new CategoryService(_categoryRepository);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnCategory()
        {
            // Arrange
            var categoryId = _fixture.Create<int>();
            var category = _fixture.Create<Category>();
            //var category = new Category() { Id = categoryId, Name = "nome", Situation = true, Products = new List<Product>() };
            _categoryRepository.GetByIdAsync(categoryId).Returns(category);
            var categoryService = new CategoryService(_categoryRepository);

            // Act
            var result = await categoryService.GetByIdAsync(categoryId);

            // Assert
            result.Situation.Should().Be(category.Situation);
            result.Id.Should().Be(category.Id);
            result.Name.Should().Be(category.Name);
        }
    }
}
