using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoliceRecruitmentAPI.Core.ModelDtos;
using PoliceRecruitmentAPI.Services.Interfaces;

namespace PoliceRecruitmentAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AppealController : ControllerBase
	{
		public IConfiguration _configuration;
		private readonly ILogger<AppealController> _logger;
		public readonly IAppealService _candidateService;

		public AppealController(ILogger<AppealController> logger, IConfiguration configuration, IAppealService candidateService)
		{
			_logger = logger;
			_configuration = configuration;
			_candidateService = candidateService;
		}

		[HttpGet("GetAppeal")]
		public async Task<IActionResult> GetCard(long? CandidateID, string? UserId)
		{
			try
			{
				AppealDto model = new AppealDto();
				model.CandidateID = CandidateID;
				model.UserId = UserId;
				if (model.BaseModel == null)
				{
					model.BaseModel = new BaseModel();
				}
				model.BaseModel.OperationType = "GetAppeal";

				dynamic userDetail = await _candidateService.Get(model);

				return userDetail;

			}
			catch (Exception ex)
			{
				return new JsonResult(new { message = ex.Message }) { StatusCode = StatusCodes.Status500InternalServerError };
			}
		}
		[HttpPost("Insert")]
		public async Task<IActionResult> Insert([FromBody] AppealDto user)
		{
			try
			{
				if (user.BaseModel == null)
				{
					user.BaseModel = new BaseModel();
				}
				user.BaseModel.OperationType = "Insert";
				var result = await _candidateService.Appeal(user);
				return result;
			}
			catch (Exception)
			{
				throw;
			}

		}
	}
}
