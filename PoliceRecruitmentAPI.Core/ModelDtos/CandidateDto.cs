using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PoliceRecruitmentAPI.Core.ModelDtos
{
    public class CandidateDto
    {
        public BaseModel? BaseModel { get; set; }

        [Required]
        public long? CandidateID { get; set; }

        [Required]
        [StringLength(100)]
        public string? UserId { get; set; }

        [StringLength(4)]
        public string? RecruitmentYear { get; set; }

        [StringLength(100)]
        public string? OfficeName { get; set; }

        [StringLength(100)]
        public string? PostName { get; set; }

        [Required]
        public long? ApplicationNo { get; set; }

        [StringLength(100)]
        public string? ExaminationFee { get; set; }

        [StringLength(100)]
        public string? FullNameDevnagari { get; set; }

        [StringLength(100)]
        public string? FullNameEnglish { get; set; }

        public bool? DocumentUploaded { get; set; }

        [StringLength(100)]
        public string? MothersName { get; set; }

        [StringLength(10)]
        public string? Gender { get; set; }

        [StringLength(10)]
        public string? MaritalStatus { get; set; }

        public long? PassCertificationNo { get; set; }

        [Required]
        public DateTime? DOB { get; set; }

        [StringLength(3)]
        public string? Age { get; set; }

        [StringLength(500)]
        public string? Address { get; set; }

        public int? PinCode { get; set; }

        public int? MobileNumber { get; set; }

        [EmailAddress]
        public string? EmailId { get; set; }

        [StringLength(500)]
        public string? PermanentAddress { get; set; }

        public int? PermanentPinCode { get; set; }

        [StringLength(50)]
        public string? Nationality { get; set; }

        [StringLength(50)]
        public string? Religion { get; set; }

        [StringLength(50)]
        public string? Cast { get; set; }

        [StringLength(50)]
        public string? SubCast { get; set; }

        public bool? PartTime { get; set; }

        public bool? ProjectSick { get; set; }

        public bool? ExServiceman { get; set; }

        public bool? EarthquakeAffected { get; set; }

        public bool? MeasurementStatus { get; set; }

        public decimal? Height { get; set; }

        public decimal? Chest_Inhale { get; set; }

        public decimal? Chest_normal { get; set; }
    }
}
