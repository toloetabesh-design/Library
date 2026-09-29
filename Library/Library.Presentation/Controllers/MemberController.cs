using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var members = await _memberService.GetAsync();

            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var member = await _memberService.GetByIdAsync(id);

            if (member == null)
                return NotFound();

            return Ok(member);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MemberDto memberDto)
        {
            await _memberService.AddAsync(memberDto);

            return Ok(memberDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(MemberDto memberDto)
        {
            await _memberService.UpdateAsync(memberDto);

            return Ok(memberDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _memberService.DeleteAsync(id);

            return Ok();
        }
    }
}