using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PoliceRecruitmentAPI.Core.ModelDtos
{
	public class DocumentDto
	{
		public BaseModel? BaseModel { get; set; }
		public string? Id { get; set; }
		public string? UserId { get; set; }
		public string? CandidateId { get; set; }
		public string? Status { get; set; }
		public string? Stage { get; set; }
		public List<DocumentData>? DocumentData { get; set; }
		public DataTable? DataTable { get; set; }
	}
	public class DocumentData
	{
		public string? Document { get; set; }
		public string? DocumentName { get; set; }
		public string? Status { get; set; }
	}
}
