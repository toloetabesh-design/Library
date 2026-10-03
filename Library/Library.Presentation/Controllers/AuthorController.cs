using Library.Application.Interfaces; 
using Library.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Library.Application.Interfaces; // این نیم‌اسپیس را طبق پروژه خودتان چک کنید

namespace Library.Presentation.Controllers // نیم‌اسپیس خودتان را بگذارید
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly ILogger<AuthorController> _logger;

        // کانستراکتور برای تزریق وابستگی‌ها
        public AuthorController(IAuthorService authorService, ILogger<AuthorController> logger)
        {
            _authorService = authorService;
            _logger = logger;
        }

        // متد دریافت همه نویسندگان
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                // این خط دیگر خطا نمی‌دهد چون سرویس شما اصلاح شده است
                var authors = await _authorService.GetAllAuthorsAsync();

                return Ok(authors);
            }
            catch (Exception ex)
            {
                // لاگ کردن خطا برای دیباگ راحت‌تر
                _logger.LogError(ex, "خطایی در دریافت لیست نویسندگان رخ داد.");

                return StatusCode(500, "خطای داخلی سرور");
            }
        }
    }
}
