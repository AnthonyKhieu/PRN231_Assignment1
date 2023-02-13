using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DataSeeding
{
    public class MemberSeeding : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasData(
                new Member
                {
                    MemberId= 1,
                    Email = "member1@gmail.com",
                    CompanyName = "Microsoft",
                    City = "LA",
                    Country = "America",
                    Password = "P@ssword12345"
                    
                },
                new Member
                {
                    MemberId = 2,
                    Email = "member2@gmail.com",
                    CompanyName = "Vingroup",
                    City = "Hanoi",
                    Country = "Vietnam",
                    Password = "P@ssword12345"
                }
            );
        }
    }
}
