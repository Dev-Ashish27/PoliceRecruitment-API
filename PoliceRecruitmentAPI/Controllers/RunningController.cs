using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoliceRecruitmentAPI.Core.ModelDtos;
using PoliceRecruitmentAPI.Services.Interfaces;
using System.Data;

namespace PoliceRecruitmentAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RunningController : ControllerBase
	{
		public IConfiguration _configuration;
		private readonly ILogger<RunningController> _logger;
		public readonly IRunningService _candidateService;

		public RunningController(ILogger<RunningController> logger, IConfiguration configuration, IRunningService candidateService)
		{
			_logger = logger;
			_configuration = configuration;
			_candidateService = candidateService;
		}

		[HttpGet("GetAll100")]
		public async Task<IActionResult> GetAll100(string? UserId)
		{
			try
			{
				RunningDto model = new RunningDto();
				model.UserId = UserId;
				if (model.BaseModel == null)
				{
					model.BaseModel = new BaseModel();
				}
				model.BaseModel.OperationType = "GetAll100";

				dynamic userDetail = await _candidateService.Get(model);

				return userDetail;

			}
			catch (Exception ex)
			{
				return new JsonResult(new { message = ex.Message }) { StatusCode = StatusCodes.Status500InternalServerError };
			}
		}
		[HttpGet("Get100")]
		public async Task<IActionResult> Get100(string? UserId,long? CandidateId,string? Id)
		{
			try
			{
				RunningDto model = new RunningDto();
				model.UserId = UserId;
				model.Id = Id;
				model.CandidateID = CandidateId;
				if (model.BaseModel == null)
				{
					model.BaseModel = new BaseModel();
				}
				model.BaseModel.OperationType = "Get100";

				dynamic userDetail = await _candidateService.Running(model);

				return userDetail;

			}
			catch (Exception ex)
			{
				return new JsonResult(new { message = ex.Message }) { StatusCode = StatusCodes.Status500InternalServerError };
			}
		}
		[HttpGet("GetGroup100")]
		public async Task<IActionResult> GetGroup100(string? Group,DateTime? Date, string? UserId)
		{
			try
			{
				RunningDto model = new RunningDto();
				model.Group = Group;
				model.Date = Date;
				model.UserId = UserId;
				if (model.BaseModel == null)
				{
					model.BaseModel = new BaseModel();
				}
				model.BaseModel.OperationType = "GetGroup100";

				dynamic userDetail = await _candidateService.Get(model);

				return userDetail;

			}
			catch (Exception ex)
			{
				return new JsonResult(new { message = ex.Message }) { StatusCode = StatusCodes.Status500InternalServerError };
			}
		}
		[HttpPost("Insert100")]
		public async Task<IActionResult> Insert([FromBody] RunningDto user)
		{
			try
			{
				if (user.BaseModel == null)
				{
					user.BaseModel = new BaseModel();
				}
				user.BaseModel.OperationType = "Insert100";
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add("ChestNo", typeof(string));
				dataTable.Columns.Add("CandidateId", typeof(string));
				dataTable.Columns.Add("Group", typeof(string));
				dataTable.Columns.Add("StartTime", typeof(string));
				dataTable.Columns.Add("EndTime", typeof(string));
				dataTable.Columns.Add("Duration", typeof(string));
				dataTable.Columns.Add("Signature", typeof(string));
				dataTable.Columns.Add("Date", typeof(DateTime));

				foreach (var privilage in user.runningData)
				{
					dataTable.Rows.Add(
						privilage.ChestNo,
						privilage.CandidateId,
						privilage.Group,
						privilage.StartTime,
						privilage.EndTime,
						privilage.Duration,
						privilage.Signature,
						privilage.Date
					);
				}
				user.runningData = null;
				user.DataTable = dataTable;
				var result = await _candidateService.Running(user);
				return result;
			}
			catch (Exception)
			{
				throw;
			}

		}
		[HttpPost("Update100")]
		public async Task<IActionResult> Update100([FromBody] RunningDto user)
		{
			try
			{
				if (user.BaseModel == null)
				{
					user.BaseModel = new BaseModel();
				}
				user.BaseModel.OperationType = "Update100";
				var result = await _candidateService.Running(user);
				return result;
			}
			catch (Exception)
			{
				throw;
			}

		}
		[HttpPost("UpdateSign100")]
		public async Task<IActionResult> UpdateSign([FromBody] RunningDto user)
		{
			try
			{
				if (user.BaseModel == null)
				{
					user.BaseModel = new BaseModel();
				}
				user.BaseModel.OperationType = "UpdateSign100";
				var result = await _candidateService.Running(user);
				return result;
			}
			catch (Exception)
			{
				throw;
			}

		}
		[HttpGet("GetAll800")]
		public async Task<IActionResult> GetAll800(string? UserId)
		{
			try
			{
				RunningDto model = new RunningDto();
				model.UserId = UserId;
				if (model.BaseModel == null)
				{
					model.BaseModel = new BaseModel();
				}
				model.BaseModel.OperationType = "GetAll800";

				dynamic userDetail = await _candidateService.Get800(model);

				return userDetail;

			}
			catch (Exception ex)
			{
				return new JsonResult(new { message = ex.Message }) { StatusCode = StatusCodes.Status500InternalServerError };
			}
		}
		[HttpGet("Get800")]
		public async Task<IActionResult> Get800(string? UserId, long? CandidateId, string? Id)
		{
			try
			{
				RunningDto model = new RunningDto();
				model.UserId = UserId;
				model.Id = Id;
				model.CandidateID = CandidateId;
				if (model.BaseModel == null)
				{
					model.BaseModel = new BaseModel();
				}
				model.BaseModel.OperationType = "Get800";

				dynamic userDetail = await _candidateService.Running800(model);

				return userDetail;

			}
			catch (Exception ex)
			{
				return new JsonResult(new { message = ex.Message }) { StatusCode = StatusCodes.Status500InternalServerError };
			}
		}
		[HttpGet("GetGroup800")]
		public async Task<IActionResult> GetGroup800(string? Group, DateTime? Date, string? UserId)
		{
			try
			{
				RunningDto model = new RunningDto();
				model.Group = Group;
				model.Date = Date;
				model.UserId = UserId;
				if (model.BaseModel == null)
				{
					model.BaseModel = new BaseModel();
				}
				model.BaseModel.OperationType = "GetGroup800";

				dynamic userDetail = await _candidateService.Get800(model);

				return userDetail;

			}
			catch (Exception ex)
			{
				return new JsonResult(new { message = ex.Message }) { StatusCode = StatusCodes.Status500InternalServerError };
			}
		}
		[HttpPost("Insert800")]
		public async Task<IActionResult> Insert800([FromBody] RunningDto user)
		{
			try
			{
				if (user.BaseModel == null)
				{
					user.BaseModel = new BaseModel();
				}
				user.BaseModel.OperationType = "Insert800";
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add("ChestNo", typeof(string));
				dataTable.Columns.Add("CandidateId", typeof(string));
				dataTable.Columns.Add("Group", typeof(string));
				dataTable.Columns.Add("StartTime", typeof(string));
				dataTable.Columns.Add("EndTime", typeof(string));
				dataTable.Columns.Add("Duration", typeof(string));
				dataTable.Columns.Add("Signature", typeof(string));
				dataTable.Columns.Add("Date", typeof(DateTime));

				foreach (var privilage in user.runningData)
				{
					dataTable.Rows.Add(
						privilage.ChestNo,
						privilage.CandidateId,
						privilage.Group,
						privilage.StartTime,
						privilage.EndTime,
						privilage.Duration,
						privilage.Signature,
						privilage.Date
					);
				}
				user.runningData = null;
				user.DataTable = dataTable;
				var result = await _candidateService.Running800(user);
				return result;
			}
			catch (Exception)
			{
				throw;
			}

		}
		[HttpPost("Update800")]
		public async Task<IActionResult> Update800([FromBody] RunningDto user)
		{
			try
			{
				if (user.BaseModel == null)
				{
					user.BaseModel = new BaseModel();
				}
				user.BaseModel.OperationType = "Update800";
				var result = await _candidateService.Running800(user);
				return result;
			}
			catch (Exception)
			{
				throw;
			}

		}
		[HttpPost("UpdateSign800")]
		public async Task<IActionResult> UpdateSign800([FromBody] RunningDto user)
		{
			try
			{
				if (user.BaseModel == null)
				{
					user.BaseModel = new BaseModel();
				}
				user.BaseModel.OperationType = "UpdateSign800";
				var result = await _candidateService.Running800(user);
				return result;
			}
			catch (Exception)
			{
				throw;
			}

		}
		[HttpGet("GetAll1600")]
		public async Task<IActionResult> GetAll1600(string? UserId)
		{
			try
			{
				RunningDto model = new RunningDto();
				model.UserId = UserId;
				if (model.BaseModel == null)
				{
					model.BaseModel = new BaseModel();
				}
				model.BaseModel.OperationType = "GetAll1600";

				dynamic userDetail = await _candidateService.Get1600(model);

				return userDetail;

			}
			catch (Exception ex)
			{
				return new JsonResult(new { message = ex.Message }) { StatusCode = StatusCodes.Status500InternalServerError };
			}
		}
		[HttpGet("Get1600")]
		public async Task<IActionResult> Get1600(string? UserId, long? CandidateId, string? Id)
		{
			try
			{
				RunningDto model = new RunningDto();
				model.UserId = UserId;
				model.Id = Id;
				model.CandidateID = CandidateId;
				if (model.BaseModel == null)
				{
					model.BaseModel = new BaseModel();
				}
				model.BaseModel.OperationType = "Get1600";

				dynamic userDetail = await _candidateService.Running1600(model);

				return userDetail;

			}
			catch (Exception ex)
			{
				return new JsonResult(new { message = ex.Message }) { StatusCode = StatusCodes.Status500InternalServerError };
			}
		}
		[HttpGet("GetGroup1600")]
		public async Task<IActionResult> GetGroup1600(string? Group, DateTime? Date, string? UserId)
		{
			try
			{
				RunningDto model = new RunningDto();
				model.Group = Group;
				model.Date = Date;
				model.UserId = UserId;
				if (model.BaseModel == null)
				{
					model.BaseModel = new BaseModel();
				}
				model.BaseModel.OperationType = "GetGroup1600";

				dynamic userDetail = await _candidateService.Get1600(model);

				return userDetail;

			}
			catch (Exception ex)
			{
				return new JsonResult(new { message = ex.Message }) { StatusCode = StatusCodes.Status500InternalServerError };
			}
		}
		[HttpPost("Insert1600")]
		public async Task<IActionResult> Insert1600([FromBody] RunningDto user)
		{
			try
			{
				if (user.BaseModel == null)
				{
					user.BaseModel = new BaseModel();
				}
				user.BaseModel.OperationType = "Insert1600";
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add("ChestNo", typeof(string));
				dataTable.Columns.Add("CandidateId", typeof(string));
				dataTable.Columns.Add("Group", typeof(string));
				dataTable.Columns.Add("StartTime", typeof(string));
				dataTable.Columns.Add("EndTime", typeof(string));
				dataTable.Columns.Add("Duration", typeof(string));
				dataTable.Columns.Add("Signature", typeof(string));
				dataTable.Columns.Add("Date", typeof(DateTime));

				foreach (var privilage in user.runningData)
				{
					dataTable.Rows.Add(
						privilage.ChestNo,
						privilage.CandidateId,
						privilage.Group,
						privilage.StartTime,
						privilage.EndTime,
						privilage.Duration,
						privilage.Signature,
						privilage.Date
					);
				}
				user.runningData = null;
				user.DataTable = dataTable;
				var result = await _candidateService.Running1600(user);
				return result;
			}
			catch (Exception)
			{
				throw;
			}

		}
		[HttpPost("Update1600")]
		public async Task<IActionResult> Update1600([FromBody] RunningDto user)
		{
			try
			{
				if (user.BaseModel == null)
				{
					user.BaseModel = new BaseModel();
				}
				user.BaseModel.OperationType = "Update1600";
				var result = await _candidateService.Running1600(user);
				return result;
			}
			catch (Exception)
			{
				throw;
			}

		}
		[HttpPost("UpdateSign1600")]
		public async Task<IActionResult> UpdateSign1600([FromBody] RunningDto user)
		{
			try
			{
				if (user.BaseModel == null)
				{
					user.BaseModel = new BaseModel();
				}
				user.BaseModel.OperationType = "UpdateSign1600";
				var result = await _candidateService.Running1600(user);
				return result;
			}
			catch (Exception)
			{
				throw;
			}

		}
	}
}
