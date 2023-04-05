using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProduct.Application.Models;
using MyProduct.Application.Services.Interfaces;
using MyProduct.Application.ViewModels;

namespace MyProduct.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> Create([FromBody] CreateProductRequest request)
        {
            var category = await _productService.CreateAsync(request);

            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryViewModel>>> GetAll()
        {
            var products = await _productService.GetAllAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryViewModel>> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryViewModel>> Update(int id, [FromBody] UpdateProductViewModel request)
        {
            var category = await _productService.UpdateAsync(id, request);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost("search")]
        public async Task<ActionResult<List<CategoryViewModel>>> Search([FromBody] ProductFilter filter)
        {
            if (filter?.Description == null && filter?.Situation == null && filter?.Category == null) return BadRequest("Preencha ao menos um campo do filtro");

            var result = await _productService.SearchAsync(filter);
            return Ok(result);
        }
    }
}
