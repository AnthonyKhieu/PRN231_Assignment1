using BusinessObject;
using DataAccess;
using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class MemberRepository : IMemberRepository
    {
        public void AddMember(MemberRespond m)
        {
            MemberDAO.AddMember(m);
        }

        public void DeleteMember(Member member)
        {
            MemberDAO.DeleteMember(member);
        }

        public Member GetMemberByID(int id)
        {
           return MemberDAO.FindMemberById(id);
        }

        public List<Member> GetMembers()
        {
            return MemberDAO.GetAllMembers();
        }

        public void UpdateMember(int id, MemberRespond m)
        {
            MemberDAO.UpdateMember(id, m);
        }

    }
}
