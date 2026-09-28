using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}