using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceRecruitmentAPI.Core.ModelDtos
{
    public class ScanningdocDto
    {
        public BaseModel? BaseModel { get; set; }
        public long? CandidateID { get; set; }
        public string? UserId { get; set; }
        public string? ChestNo { get; set; }
        public string? Thumbstring { get; set; }
        public string? Imagestring { get; set; }
        public DateTime? Date { get; set; }
    }
}
