using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc; 



namespace Library.Presentation.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        protected readonly ILogger _logger;

 

        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService, ILogger logger)
        {
            _authorService = authorService;
            _logger = logger;
        }
 

        [System.Web.Http.HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("سلام از کنترلر مشتری!"); // مستقیم استفاده می‌شود
            var authors = await _authorService.GetAsync();

            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("سلام از کنترلر مشتری!"); // مستقیم استفاده می‌شود
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