using BusinessObject;
using DataAccess.DTOs;
using eStoreAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MemberDAO
    {
        public static AppDBContext context = new AppDBContext();

        public MemberDAO()
        {
        }


        public static List<Member> GetAllMembers()
        {
            var members = new List<Member>();
            try
            {
                members = context.Members.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return members;
        }

        public static Member FindMemberById(int pid)
        {
            Member p = new Member();
            try
            {
                p = context.Members.SingleOrDefault(p => p.MemberId == pid);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return p;
        }

        public static void AddMember(MemberDTO memberRespond)
        {
            try
            {
                var member = new Member
                {
                    Email = memberRespond.Email,
                    CompanyName = memberRespond.CompanyName,
                    City = memberRespond.City,
                    Country = memberRespond.Country,
                    Password = memberRespond.Password,
                };
                context.Members.Add(member);
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateMember(int id, MemberDTO memberRespond)
        {
            try
            {
                var memberUpdate = context.Members.SingleOrDefault(p => p.MemberId == id);
                memberUpdate.Email = memberRespond.Email;
                memberUpdate.CompanyName = memberRespond.CompanyName;
                memberUpdate.City = memberRespond.City;
                memberUpdate.Country = memberRespond.Country;
                memberUpdate.Password = memberRespond.Password;
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteMember(Member member)
        {
            try
            {
                var mem = context.Members.SingleOrDefault(m => m.MemberId == member.MemberId);
                context.Members.Remove(mem);
                context.SaveChanges();  

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
    }
}
