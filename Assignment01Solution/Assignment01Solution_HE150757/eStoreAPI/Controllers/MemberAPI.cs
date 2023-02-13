using BusinessObject;
using DataAccess.DTOs;
using eStoreAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberAPI : ControllerBase
    {
        private readonly IMemberRepository repository;

        public MemberAPI(IMemberRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]

        public IActionResult GetAll()
        {
            List<Member> members = repository.GetMembers();
            return Ok(members);
        }


        [HttpPost]
        public IActionResult AddMember(MemberDTO memberDto)
        {
            repository.AddMember(memberDto);
            return Ok(new BaseDTO<MemberDTO>()
            {
                Success = true,
                Message = "Create new member success",
                Data = memberDto,
            });
        }
        [HttpPut("id")]
        public IActionResult UpdateMember(int id, MemberDTO memberDto)
        {
            var mTmp = repository.GetMemberByID(id);
            if (mTmp == null)
            {
                return NotFound();
            }
            repository.UpdateMember(id, memberDto);
            return Ok(new BaseDTO<MemberDTO>()
            {
                Success = true,
                Message = $"Update member id {id} success!",
                Data = memberDto,
            });
        }

        [HttpDelete("id")]
        public IActionResult DeleteMemeber(int id)
        {
            var mem = repository.GetMemberByID(id);
            if(mem == null)
            {
                return NotFound();
            }
            repository.DeleteMember(mem);
            return Ok(new BaseDTO<Member>()
            {
                Success = true,
                Message = $"Delete member id {id} success!",
                Data=mem,             
            });  
        }
    }
}
