using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPortal.Infrastruct.Domain.Entities
{
	public class Enum
	{
		public enum UserType
		{
			Admin,
			Manager,
			Teacher,
			Student
		}

		public enum Status
		{
			Delete,
			Active,
			Passive
		}
	}
}
