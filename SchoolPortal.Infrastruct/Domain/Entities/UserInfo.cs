using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPortal.Infrastruct.Domain.Entities
{
	public class UserInfo
	{
		[Key]
		public Guid Guid { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Phone { get; set; }
		public string? Phone2 { get; set; }
		public string? Photo { get; set; }
		public Enum.UserType UserType { get; set; }
		public Guid FK_SchoolDetail { get; set; }
		public Enum.Status Status { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime? UpdateTime { get; set; }
		public string RefreshToken { get; set; }
		public DateTime ExpireDate { get; set; }
	}
}
