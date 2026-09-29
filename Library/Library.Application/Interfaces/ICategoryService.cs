using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.DTOs;

namespace Library.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAsync();

        Task<CategoryDto?> GetByIdAsync(int id);

        Task AddAsync(CategoryDto categoryDto);

        Task UpdateAsync(CategoryDto categoryDto);

        Task DeleteAsync(int id);
    }
}