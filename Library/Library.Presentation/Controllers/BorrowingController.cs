using Microsoft.AspNetCore.Mvc;
using Library.Application.Interfaces; 
using Library.Domain.Entities; 

namespace YourProject.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BorrowingController : ControllerBase
{
    private readonly IBorrowingService _borrowingService;
    private readonly ILogger<BorrowingController> _logger;

    // تزریق سرویس و لاگر از طریق سازنده
    public BorrowingController(IBorrowingService borrowingService, ILogger<BorrowingController> logger)
    {
        _borrowingService = borrowingService;
        _logger = logger;
    }

    /// <summary>
    /// ثبت یک عملیات امانت گرفتن جدید
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Borrow([FromBody] BorrowRequest request)
    {
        _logger.LogInformation("درخواست امانت گرفتن برای کالا با کد: {ItemId} توسط کاربر: {UserId}",
            request.ItemId, request.UserId);

        try
        {
            // ارسال درخواست به لایه بیزنس (Service)
            var result = await _borrowingService.ProcessBorrowingAsync(request);

            if (result.IsSuccess)
            {
                _logger.LogInformation("عملیات امانت گرفتن با موفقیت انجام شد. شماره رسید: {ReceiptId}", result.Id);
                return Ok(result);
            }

            _logger.LogWarning("عملیات امانت گرفتن شکست خورد: {ErrorMessage}", result.ErrorMessage);
            return BadRequest(new { message = result.ErrorMessage });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "خطای غیرمنتظره در BorrowingController هنگام ثبت امانت");
            return StatusCode(500, "خطایی در سرور رخ داده است.");
        }
    }
}

// مدل درخواست (DTO) برای اینکه کاربر اطلاعات را در بدنه (Body) بفرستد
public record BorrowRequest(int ItemId, int UserId, int Quantity);

// مدل پاسخ برای اینکه نتیجه را به کاربر برگردانیم
public record BorrowResponse(bool IsSuccess, int? Id, string? ErrorMessage);

