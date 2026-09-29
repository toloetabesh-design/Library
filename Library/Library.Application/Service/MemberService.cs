using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberService(
            IMemberRepository memberRepository,
            IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MemberDto>> GetAsync()
        {
            var members = await _memberRepository.GetAsync();

            return _mapper.Map<IEnumerable<MemberDto>>(members);
        }

        public async Task<MemberDto?> GetByIdAsync(int id)
        {
            var member = await _memberRepository.GetByIdAsync(id);

            if (member == null)
                return null;

            return _mapper.Map<MemberDto>(member);
        }

        public async Task AddAsync(MemberDto memberDto)
        {
            var member = _mapper.Map<Member>(memberDto);

            await _memberRepository.AddAsync(member);
        }

        public async Task UpdateAsync(MemberDto memberDto)
        {
            var member = _mapper.Map<Member>(memberDto);

            await _memberRepository.UpdateAsync(member);
        }

        public async Task DeleteAsync(int id)
        {
            await _memberRepository.DeleteAsync(id);
        }
    }
}