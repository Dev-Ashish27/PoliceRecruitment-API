using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoliceRecruitmentAPI.Core.ModelDtos;
using PoliceRecruitmentAPI.Services.ApiServices;
using PoliceRecruitmentAPI.Services.Interfaces;

namespace PoliceRecruitmentAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShotPutController : ControllerBase
	{
		public IConfiguration _configuration;
		private readonly ILogger<ShotPutController> _logger;
		public readonly IShotPutService _shotput;

		public ShotPutController(ILogger<ShotPutController> logger, IConfiguration configuration, IShotPutService shotput)
		{
			_logger = logger;
			_configuration = configuration;
			_shotput = shotput;
		}




		[HttpPost("Insert")]
		public async Task<IActionResult> Insert([FromBody] ShotPutDto user)
		{
			try
			{
				if (user.BaseModel == null)
				{
					user.BaseModel = new BaseModel();
				}
				if (user.Id == null)
				{
					user.BaseModel.OperationType = "Insert";
				}
				else
				{
					user.BaseModel.OperationType = "Update";
				}
				var result = await _shotput.ShotPut(user);
				return result;
			}
			catch (Exception)
			{
				throw;
			}

		}

		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAll()
		{
			try
			{
				ShotPutDto model = new ShotPutDto();
				if (model.BaseModel == null)
				{
					model.BaseModel = new BaseModel();
				}
				model.BaseModel.OperationType = "GetAll";

				dynamic userDetail = await _shotput.ShotPut(model);
				return userDetail;

			}
			catch (Exception ex)
			{
				return new JsonResult(new { message = ex.Message }) { StatusCode = StatusCodes.Status500InternalServerError };
			}
		}


		[HttpGet("Get")]
		public async Task<IActionResult> Get(Guid? Id)
		{
			try
			{
				ShotPutDto model = new ShotPutDto();
				model.Id = Id;
				if (model.BaseModel == null)
				{
					model.BaseModel = new BaseModel();
				}
				model.BaseModel.OperationType = "Get";

				dynamic userDetail = await _shotput.ShotPut(model);

				return userDetail;

			}
			catch (Exception ex)
			{
				return new JsonResult(new { message = ex.Message }) { StatusCode = StatusCodes.Status500InternalServerError };
			}
		}
	}
}
