using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceRecruitmentAPI.Core.ModelDtos
{
	public class running
	{

		public string? CandidateId { get; set; }
		public string? ChestNo { get; set; }
		public TimeSpan? StartTime { get; set; }
		public TimeSpan? EndTime { get; set; }
		public string? Group { get; set; }
		public string? Duration { get; set; }
		public string? Signature { get; set; }
		public DateTime? Date { get; set; }
	}
	public class RunningDto
	{
		public string? Id { get; set; }
		public List<running>? runningData { get; set; }
		public DataTable? DataTable { get; set; }

		public BaseModel? BaseModel { get; set; }
		public long? CandidateID { get; set; }
		public string? UserId { get; set; }
		public string? ChestNo { get; set; }
		public TimeSpan? StartTime { get; set; }
		public TimeSpan? EndTime { get; set; }
		public string? Group { get; set; }
		public string? NoOfAttemt { get; set; }
		public string? Duration { get; set; }
		public string? Signature { get; set; }
		public string? Score { get; set; }
		public DateTime? Date { get; set; }
	}
}
