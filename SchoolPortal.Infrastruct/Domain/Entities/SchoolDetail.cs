using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPortal.Infrastruct.Domain.Entities
{
	public class SchoolDetail
	{
		[Key]
		public Guid Guid { get; set; }
		public string SchoolName { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public Enum.Status Status { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime? UpdateDate { get; set; }

	}
}
