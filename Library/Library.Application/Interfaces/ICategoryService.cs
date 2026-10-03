using Library.Application.DTOs;

namespace Library.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAsync();
        Task<CategoryDto?> GetByIdAsync(int id);

        
        Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto request);

        Task UpdateAsync(CategoryDto categoryDto);
        Task DeleteAsync(int id);
    }

    public class CreateCategoryDto
    {
    }
}
