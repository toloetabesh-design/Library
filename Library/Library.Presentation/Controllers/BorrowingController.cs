using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowingController : ControllerBase
    {
        private readonly IBorrowingService _borrowingService;
        private readonly ILogger<BorrowingController> _logger;

        public BorrowingController(IBorrowingService borrowingService, ILogger<BorrowingController> logger)
        {
            _borrowingService = borrowingService;
            _logger = logger;
        }

        // GET: api/borrowing
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var borrowings = await _borrowingService.GetAsync();
            return Ok(borrowings);
        }

        // GET: api/borrowing/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var borrowing = await _borrowingService.GetByIdAsync(id);
            if (borrowing == null)
            {
                return NotFound($"Borrowing with ID {id} not found.");
            }
            return Ok(borrowing);
        }

        // POST: api/borrowing
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBorrowingDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var result = await _borrowingService.ProcessBorrowingAsync(request);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while processing borrowing.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // DELETE: api/borrowing/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _borrowingService.DeleteAsync(id);
            return NoContent();
        }
    }
}
