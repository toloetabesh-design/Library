using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Interfaces
{
    public interface IAuthorService
    {
        // دریافت لیست تمام نویسندگان
        Task<IEnumerable<Author>> GetAllAuthorsAsync();

        // دریافت یک نویسنده با شناسه
        // نوع خروجی Author? است تا اگر یافت نشد، null برگرداند
        Task<Author?> GetAuthorByIdAsync(int id);

        // افزودن نویسنده جدید
        Task AddAuthorAsync(Author author);

        // حذف نویسنده
        // خروجی bool است تا بفهمیم حذف موفق بوده یا نه
        Task<bool> DeleteAuthorAsync(int id);
    }
}
