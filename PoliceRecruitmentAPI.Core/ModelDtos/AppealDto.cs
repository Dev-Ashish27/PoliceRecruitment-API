using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceRecruitmentAPI.Core.ModelDtos
{
	public class AppealDto
	{
		public BaseModel? BaseModel { get; set; }

		[Required]
		public long? CandidateID { get; set; }

        [Required]
        [StringLength(100)]
        public string? UserId { get; set; }

        [StringLength(100)]
        public string? ApprovedBy { get; set; }

		[Required]
		public DateTime? Date { get; set; }

		[StringLength(500)]
		public string? Remark { get; set; }
	}
}
