using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPortal.Business.School.Model.Response
{
    public class ResponseStudentList
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string? Phone2 { get; set; }
        public string Mail { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
