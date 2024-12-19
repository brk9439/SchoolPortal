using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPortal.Infrastruct.Domain.Entities
{
	public class ExamInfoDetail
	{
		[Key]
		public Guid Guid { get; set; }
		public Guid Fk_ExamInfo { get; set; }
		public Guid Fk_SchoolDetail { get; set; }
		public Guid Fk_UserInfo_Student { get; set; }
		public Decimal ExamScore { get; set; }
		public Decimal SchoolarshipRate { get; set; }
		public Decimal SchoolarshipStatus { get; set; }
		public Enum.Status Status { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }

	}
}
