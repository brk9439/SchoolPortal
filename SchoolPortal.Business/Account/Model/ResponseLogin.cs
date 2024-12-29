using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enum = SchoolPortal.Infrastruct.Domain.Entities.Enum;

namespace SchoolPortal.Business.Account.Model
{
    public class ResponseLogin
    {
        public Guid Id { get; set; }
        public Guid SchoolId { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public Enum.UserType UserType { get; set; }
    }
}
