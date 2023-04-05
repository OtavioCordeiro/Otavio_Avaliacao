using Azure;
using Microsoft.AspNetCore.Mvc;
using MyProduct.Application.Models;
using MyProduct.Application.Services.Interfaces;
using MyProduct.Application.ViewModels;

namespace MyProduct.Api.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryViewModel>> Create([FromBody] CreateCategoryRequest request)
        {
            var category = await _categoryService.CreateAsync(request);

            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        [HttpGet]
        public async Task<ActionResult<CategoryViewModel>> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryViewModel>> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryViewModel>> Update(int id, [FromBody] UpdateCategoryViewModel request)
        {
            var category = await _categoryService.UpdateAsync(id, request);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost("search")]
        public async Task<ActionResult<List<CategoryViewModel>>> Search([FromBody] CategoryFilter filter)
        {
            if (filter.Name == null && filter.Situation == null) return BadRequest("Preencha ao menos um campo do filtro");

            var result = await _categoryService.SearchAsync(filter);
            return Ok(result);
        }
    }
}
