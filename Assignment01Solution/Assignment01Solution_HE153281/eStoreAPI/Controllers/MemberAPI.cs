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
        public IActionResult AddMember(MemberRespond memberRespond)
        {
            repository.AddMember(memberRespond);
            return Ok(new Respond<MemberRespond>()
            {
                Success = true,
                Message = "Create new member success",
                Data = memberRespond,
            });
        }
        [HttpPut("id")]
        public IActionResult UpdateMember(int id, MemberRespond memberRespond)
        {
            var mTmp = repository.GetMemberByID(id);
            if (mTmp == null)
            {
                return NotFound();
            }
            repository.UpdateMember(id, memberRespond);
            return Ok(new Respond<MemberRespond>()
            {
                Success = true,
                Message = $"Update member id {id} success!",
                Data = memberRespond,
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
            return Ok(new Respond<Member>()
            {
                Success = true,
                Message = $"Delete member id {id} success!",
                Data=mem,             
            });  
        }
    }
}
