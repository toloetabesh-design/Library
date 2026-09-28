using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Library.Domain.Entities
{
    public class Member
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public ICollection<Borrowing> Borrowings { get; set; }
    }
}