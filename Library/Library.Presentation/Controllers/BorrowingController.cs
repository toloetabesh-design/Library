using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowingController : ControllerBase
    {
        private readonly IBorrowingService _borrowingService;

        public BorrowingController(IBorrowingService borrowingService)
        {
            _borrowingService = borrowingService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var borrowings = await _borrowingService.GetAsync();

            return Ok(borrowings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var borrowing = await _borrowingService.GetByIdAsync(id);

            if (borrowing == null)
                return NotFound();

            return Ok(borrowing);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BorrowingDto borrowingDto)
        {
            await _borrowingService.AddAsync(borrowingDto);

            return Ok(borrowingDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(BorrowingDto borrowingDto)
        {
            await _borrowingService.UpdateAsync(borrowingDto);

            return Ok(borrowingDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _borrowingService.DeleteAsync(id);

            return Ok();
        }
    }
}