using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoliceRecruitmentAPI.Core.ModelDtos;
using PoliceRecruitmentAPI.Services.Interfaces;

namespace PoliceRecruitmentAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdmissionCardController : ControllerBase
	{
		public IConfiguration _configuration;
		private readonly ILogger<AdmissionCardController> _logger;
		public readonly IAdmissionCardService _candidateService;

		public AdmissionCardController(ILogger<AdmissionCardController> logger, IConfiguration configuration, IAdmissionCardService candidateService)
		{
			_logger = logger;
			_configuration = configuration;
			_candidateService = candidateService;
		}

		[HttpGet("GetCard")]
		public async Task<IActionResult> GetCard(long? CandidateID,string? UserId)
		{
			try
			{
				CandidateDto model = new CandidateDto();
				model.CandidateID = CandidateID;
				model.UserId = UserId;
				if (model.BaseModel == null)
				{
					model.BaseModel = new BaseModel();
				}
				model.BaseModel.OperationType = "GetAdmissionCard";

				dynamic userDetail = await _candidateService.Get(model);

				return userDetail;

			}
			catch (Exception ex)
			{
				return new JsonResult(new { message = ex.Message }) { StatusCode = StatusCodes.Status500InternalServerError };
			}
		}
	}
}
