using Azure;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Create([FromBody] CreateCategoryRequest request)
        {
            var category = _categoryService.Create(request);

            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _categoryService.GetAll();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _categoryService.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateCategoryViewModel request)
        {
            request.Id = id;
            _categoryService.Update(request);

            return Ok();
        }
    }
}
