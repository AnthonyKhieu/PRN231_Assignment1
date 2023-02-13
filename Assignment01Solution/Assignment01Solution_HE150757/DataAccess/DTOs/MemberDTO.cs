using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class MemberDTO
    {
        public string Email { get; set; }

        public string CompanyName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Password { get; set; }
    }
}
