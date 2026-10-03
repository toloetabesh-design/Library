using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Library.Application.Interfaces; 
using Library.Domain.Entities;      
namespace Library.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        // استفاده از ILogger<AuthorController> برای ثبت دقیق نام کلاس در لاگ‌ها
        protected readonly ILogger<AuthorController> _logger;
        private readonly IAuthorService _authorService;

        // تزریق وابستگی‌ها به صورت صحیح
        public AuthorController(IAuthorService authorService, ILogger<AuthorController> logger)
        {
            _authorService = authorService;
            _logger = logger;
        }

        // مثال از یک متد برای گرفتن لیست نویسندگان
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("جلب لیست تمام نویسندگان از طریق API");
                var authors = await _authorService.GetAllAuthorsAsync();
                return Ok(authors);
            }
            catch (Exception ex)
            {
                // ثبت خطا در فایل لاگ که قبلاً تنظیم کردی
                _logger.LogError(ex, "خطا در متد GetAll در AuthorController");
                return StatusCode(500, "خطایی در سرور رخ داده است.");
            }
        }

        // مثال از یک متد برای گرفتن یک نویسنده بر اساس ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                _logger.LogInformation("درخواست دریافت نویسنده با شناسه: {AuthorId}", id);
                var author = await _authorService.GetAuthorByIdAsync(id);

                if (author == null)
                {
                    _logger.LogWarning("نویسنده با شناسه {AuthorId} یافت نشد", id);
                    return NotFound();
                }

                return Ok(author);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطا در متد GetById برای شناسه: {AuthorId}", id);
                return StatusCode(500, "خطایی در سرور رخ داده است.");
            }
        }
    }
}
