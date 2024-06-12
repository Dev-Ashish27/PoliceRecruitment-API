using Microsoft.AspNetCore.Mvc;
using PoliceRecruitmentAPI.Core.ModelDtos;
using PoliceRecruitmentAPI.Services.Interfaces;

namespace PoliceRecruitmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ILogger<DashboardController> _logger;
        public readonly IDashboardService _candidateService;

        public DashboardController(ILogger<DashboardController> logger, IConfiguration configuration, IDashboardService candidateService)
        {
            _logger = logger;
            _configuration = configuration;
            _candidateService = candidateService;
        }

        [HttpGet("GetCount")]
        public async Task<IActionResult> GetCard( string? UserId)
        {
            try
            {
                CandidateDto model = new CandidateDto();
                model.UserId = UserId;                
                if (model.BaseModel == null)
                {
                    model.BaseModel = new BaseModel();
                }
                model.BaseModel.OperationType = "GetCount";

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
