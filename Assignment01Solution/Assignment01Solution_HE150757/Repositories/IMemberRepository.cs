using BusinessObject;
using DataAccess.DTOs;
using eStoreAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IMemberRepository
    {
        void AddMember(MemberDTO m);

        Member GetMemberByID(int id);

        void UpdateMember(int id, MemberDTO m);

        List<Member> GetMembers();

        void DeleteMember(Member member);  
    }
}
