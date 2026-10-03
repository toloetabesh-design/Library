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
        
        Task<IEnumerable<Author>> GetAllAuthorsAsync();

       
        Task<Author?> GetAuthorByIdAsync(int id);

        Task AddAuthorAsync(Author author);

               Task<bool> DeleteAuthorAsync(int id);
    }
}
