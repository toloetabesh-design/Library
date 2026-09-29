using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryService.GetAsync();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryDto categoryDto)
        {
            await _categoryService.AddAsync(categoryDto);

            return Ok(categoryDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            await _categoryService.UpdateAsync(categoryDto);

            return Ok(categoryDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);

            return Ok();
        }
    }
}