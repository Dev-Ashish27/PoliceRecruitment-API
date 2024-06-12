using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoliceRecruitmentAPI.Core.ModelDtos;
using PoliceRecruitmentAPI.Services.Interfaces;

namespace PoliceRecruitmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScanningdocController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ILogger<ScanningdocController> _logger;
        public readonly IScanningdocService _candidateService;

        public ScanningdocController(ILogger<ScanningdocController> logger, IConfiguration configuration, IScanningdocService candidateService)
        {
            _logger = logger;
            _configuration = configuration;
            _candidateService = candidateService;
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetCard(long? CandidateID, string? UserId)
        {
            try
            {
                ScanningdocDto model = new ScanningdocDto();
                model.CandidateID = CandidateID;
                model.UserId = UserId;
                if (model.BaseModel == null)
                {
                    model.BaseModel = new BaseModel();
                }
                model.BaseModel.OperationType = "Get";

                dynamic userDetail = await _candidateService.Scanningdoc(model);

                return userDetail;

            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = ex.Message }) { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] ScanningdocDto user)
        {
            try
            {
                if (user.BaseModel == null)
                {
                    user.BaseModel = new BaseModel();
                }
                user.BaseModel.OperationType = "Insert";
                var result = await _candidateService.Scanningdoc(user);
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
