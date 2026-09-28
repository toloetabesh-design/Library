using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Entities;
using Library.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _context;

        public MemberRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Member>> GetAllAsync()
        {
            return await _context.Members
                .Include(x => x.Borrowings)
                .ToListAsync();
        }

        public async Task<Member> GetByIdAsync(int id)
        {
            return await _context.Members
                .Include(x => x.Borrowings)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Member member)
        {
            await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Member member)
        {
            _context.Members.Update(member);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var member = await _context.Members
                .FirstOrDefaultAsync(x => x.Id == id);

            if (member != null)
            {
                _context.Members.Remove(member);
                await _context.SaveChangesAsync();
            }
        }
    }
}