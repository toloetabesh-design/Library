using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Entities;

namespace Library.Persistence.Interfaces
{
    public interface IBorrowingRepository
    {
        Task<List<Borrowing>> GetAllAsync();

        Task<Borrowing> GetByIdAsync(int id);

        Task AddAsync(Borrowing borrowing);

        Task UpdateAsync(Borrowing borrowing);

        Task DeleteAsync(int id);
    }
}