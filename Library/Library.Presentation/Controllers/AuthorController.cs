using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;



[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    // تزریق کردن ILogger از طریق سازنده (Constructor)
    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ILogger<CustomerController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("درخواست مشاهده مشتری‌ها دریافت شد.");

        try
        {
            // فرض کنید اینجا عملیاتی انجام می‌دهید
            return Ok(new { Name = "Ali" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "خطایی در دریافت اطلاعات مشتری رخ داد.");
            return StatusCode(500);
        }
    }
}

namespace Library.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var authors = await _authorService.GetAsync();

            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _authorService.GetByIdAsync(id);

            if (author == null)
                return NotFound();

            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AuthorDto authorDto)
        {
            await _authorService.AddAsync(authorDto);

            return Ok(authorDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(AuthorDto authorDto)
        {
            await _authorService.UpdateAsync(authorDto);

            return Ok(authorDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _authorService.DeleteAsync(id);

            return Ok();
        }
    }
}