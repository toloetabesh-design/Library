using Library.Application.Interfaces; 
using Library.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Library.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(IAuthorService authorService, ILogger<AuthorController> logger)
        {
            _authorService = authorService;
            _logger = logger;
        }

        // ۱. دریافت همه نویسندگان (GET)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var authors = await _authorService.GetAllAuthorsAsync();
                return Ok(authors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطایی در دریافت لیست نویسندگان رخ داد.");
                return StatusCode(500, "خطای داخلی سرور");
            }
        }

        // ۲. دریافت یک نویسنده با ID (GET)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var author = await _authorService.GetAuthorByIdAsync(id);
                if (author == null)
                    return NotFound($"نویسنده‌ای با شناسه {id} یافت نشد.");

                return Ok(author);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطا در دریافت نویسنده با شناسه {Id}", id);
                return StatusCode(500, "خطای داخلی سرور");
            }
        }

        // ۳. افزودن نویسنده جدید (POST)
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Author author)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _authorService.AddAuthorAsync(author);
                return CreatedAtAction(nameof(GetById), new { id = author.Id }, author);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطا در ایجاد نویسنده جدید");
                return StatusCode(500, "خطای داخلی سرور");
            }
        }

        // ۴. حذف نویسنده (DELETE)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var success = await _authorService.DeleteAuthorAsync(id);
                if (!success)
                    return NotFound($"نویسنده‌ای با شناسه {id} برای حذف یافت نشد.");

                return NoContent(); // کد 240 یعنی موفق آمیز بدون محتوای بازگشتی
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطا در حذف نویسنده با شناسه {Id}", id);
                return StatusCode(500, "خطای داخلی سرور");
            }
        }
    }
}
