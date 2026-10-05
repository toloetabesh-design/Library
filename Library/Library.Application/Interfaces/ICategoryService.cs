using Library.Application.DTOs;

namespace Library.Application.Interfaces
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberDto>> GetAsync();
        Task<MemberDto?> GetByIdAsync(int id);
        Task AddAsync(MemberDto memberDto);
        Task UpdateAsync(MemberDto memberDto);
        Task DeleteAsync(int id);
    }
}
