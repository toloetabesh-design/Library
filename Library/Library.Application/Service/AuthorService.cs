using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Persistence; // این خط خیلی مهم است (اضافه کنید)

namespace Library.Application.Services
{
    public class AuthorService : IAuthorService
    {
        // 1. اینجا باید AppDbContext باشد، نه DbContext
        private readonly AppDbContext _context;

        // 2. در کانستراکتور هم باید AppDbContext را بگیرید
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            // حالا که سیستم می‌داند _context از نوع AppDbContext است، Authors را می‌شناسد
            return await _context.Authors.ToListAsync();
        }
    }
}
