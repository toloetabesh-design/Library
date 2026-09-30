using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Presentation.Controllers
   

{
    // ۱. ساخت کلاس پایه
    public abstract class BaseController : ControllerBase
    {
        protected readonly ILogger _logger;

        protected BaseController(ILogger logger)
        {
            _logger = logger;
        }
    }

    // ۲. استفاده در کنترلرها
    public class CustomerController : BaseController
    {
        public CustomerController(ILogger<CustomerController> logger) : base(logger)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("سلام از کنترلر مشتری!"); // مستقیم استفاده می‌شود
            return Ok();
        }
    }
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAllAsync();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookService.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookDto bookDto)
        {
            

            return Ok(bookDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(BookDto bookDto)
        {
            await _bookService.UpdateAsync(bookDto);

            return Ok(bookDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.DeleteAsync(id);

            return Ok();
        }
    }
}