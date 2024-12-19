using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPortal.Infrastruct.Domain.Entities
{
	public class ExamInfo
	{
		[Key]
		public Guid Guid { get; set; }
		public string Name { get; set; }
		public DateTime ExamDate { get; set; }
		public int Period { get; set; }
		public DateTime StartDate { get; set; }
		public Enum.Status Status { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }
		public Guid FK_SchoolDetail { get; set; }

	}
}
