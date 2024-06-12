using System.ComponentModel.DataAnnotations;

namespace PoliceRecruitmentAPI.Core.ModelDtos
{
	public class BaseModel
    {
        [StringLength(100)]
        public string? OperationType { get; set; }

        [StringLength(100)]
        public string? Server_Value { get; set; }
    }
    public class Outcome
    {
        [Required]
        public int OutcomeId { get; set; }
        [Required]
        [StringLength(500)]
        public string OutcomeDetail { get; set; }
        [StringLength(500)]
        public string? Tokens { get; set; }
        [StringLength(500)]
        public string? Expiration { get; set; }
    }


    public class Result
    {
        public Outcome? Outcome { get; set; }
        public object? Data { get; set; }
        
        [Required]
        public Guid? UserId { get; set; }

    }
}