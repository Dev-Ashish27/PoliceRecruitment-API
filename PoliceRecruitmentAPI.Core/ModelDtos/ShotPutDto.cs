using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceRecruitmentAPI.Core.ModelDtos
{
	public class ShotPutDto
	{
		public BaseModel? BaseModel { get; set; }
		public Guid?Id { get; set; }
		public string?UserId { get; set; }
		public string?chestNo { get; set; }
		public string?startTime { get; set; }
		public string?endTime { get; set; }
		public string? groupNo { get; set; }
		public string?duration { get; set; }
		public string?isActive { get; set; }
		public string?createdBy { get; set; }
		public DateTime?createdDate { get; set; }
		public string? signature { get; set; }
		public string? fullnameenglish { get; set; }
		public string? candidateid { get; set; }

	}
}
