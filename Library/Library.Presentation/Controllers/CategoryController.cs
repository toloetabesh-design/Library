using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Library.Domain.Entities;

namespace Library.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly ILogger<CategoryController> _logger;

    public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
    {
        _categoryService = categoryService;
        _logger = logger;
    }

    // ۱. دریافت لیست تمام دسته‌بندی‌ها
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        _logger.LogInformation("درخواست دریافت لیست تمام دسته‌بندی‌ها");
        var categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }

    // ۲. دریافت یک دسته‌بندی خاص بر اساس ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        _logger.LogInformation("درخواست دریافت دسته‌بندی با آی‌دی: {Id}", id);
        var category = await _categoryService.GetCategoryByIdAsync(id);

        if (category == null)
        {
            _logger.LogWarning("دسته‌بندی با آی‌دی {Id} پیدا نشد.", id);
            return NotFound(new { message = "دسته‌بندی مورد نظر یافت نشد." });
        }

        return Ok(category);
    }

    // ۳. ایجاد یک دسته‌بندی جدید
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
    {
        _logger.LogInformation("در حال ایجاد دسته‌بندی جدید: {Name}", request.Name);

        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return BadRequest(new { message = "نام دسته‌بندی نمی‌تواند خالی باشد." });
        }

        var newCategory = await _categoryService.CreateCategoryAsync(request.Name);
        return CreatedAtAction(nameof(GetById), new { id = newCategory.Id }, newCategory);
    }

    // ۴. حذف یک دسته‌بندی
    [HttpDelete("{id}")]

}
