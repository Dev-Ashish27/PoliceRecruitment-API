using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceRecruitmentAPI.Core.ModelDtos
{
	public class heiCheMeasurement
	{
		public BaseModel? BaseModel { get; set; }
		public Guid? Id { get; set; }
		public long? candidate_id { get; set; }
		public long? hid { get; set; }
	    public decimal? Height { get; set; }
		public  decimal? Chest_normal { get; set; }
		public decimal? Chest_Inhale { get; set; }
		public string? time { get; set; } 

		public string? Verify_by { get; set; }
		public string? Interval { get; set; }
		public string? createdby { get; set; }
		public DateTime? created_date { get; set; }
		public string? UserId { get; set; }
		public string? isactive { get; set; }
	}
}
