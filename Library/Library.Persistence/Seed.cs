using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence
{
    public static class Seed
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "شازده کوچولو",
                    AuthorId = 1,
                    CategoryId = 1,
                    Price = 250000,
                    Stock = 10
                },
                new Book
                {
                    Id = 2,
                    Title = "کیمیاگر",
                    AuthorId = 1,
                    CategoryId = 1,
                    Price = 300000,
                    Stock = 8
                },
                new Book
                {
                    Id = 3,
                    Title = "صد سال تنهایی",
                    AuthorId = 1,
                    CategoryId = 1,
                    Price = 450000,
                    Stock = 5
                }
            );
        }
    }
}