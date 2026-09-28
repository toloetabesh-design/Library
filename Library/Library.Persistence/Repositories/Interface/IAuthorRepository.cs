using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Entities;

namespace Library.Persistence.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAsync();

        Task<Author> GetByIdAsync(int id);

        Task AddAsync(Author author);

        Task UpdateAsync(Author author);

        Task DeleteAsync(int id);
    }
}
