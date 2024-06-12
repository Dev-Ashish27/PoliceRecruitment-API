using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PoliceRecruitmentAPI.Core.ModelDtos;
using PoliceRecruitmentAPI.Services.Interfaces;
using System.Security.Claims;
using System.Text;

namespace PoliceRecruitmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;
        public readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IConfiguration configuration, IAuthService authService)
        {
            _logger = logger;
            _configuration = configuration;
            _authService = authService;
        }
        
        [HttpPost(Name = "Login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            try
            {
				if (model.BaseModel == null)
				{
					model.BaseModel = new BaseModel();
				}
				model.BaseModel.OperationType = "ValidateLogin";

				dynamic userDetail = await _authService.VerifyUser(model);
				var outcomeidvalue = userDetail.Value.Outcome.OutcomeId;

				//if (outcomeidvalue !=1)
    //            {
    //                return new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
    //            }
                return userDetail;
                //var passwordHasher = new PasswordHasher<LoginModel>();
                //var result = passwordHasher.VerifyHashedPassword(model, userDetail.Password, model.Password);
                //if (result == PasswordVerificationResult.Success)
                //{
                //    //return new JsonResult(new { message = "Success", data = result }) { StatusCode = StatusCodes.Status200OK };

                //    var tokenHandler = new JwtSecurityTokenHandler();
                //    var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
                //    List<Claim> userClaims = new();
                //    userClaims.Add(new Claim(nameof(result), JsonConvert.SerializeObject(result)));
                //    var claimsIdentity = new ClaimsIdentity(userClaims);

                //    var issuer = _configuration["Jwt:Issuer"];

                //    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                //    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                //    var tokeOptions = new JwtSecurityToken(issuer: _configuration["Jwt:Issuer"], audience: _configuration["Jwt:Audience"], claims: userClaims, expires: DateTime.Now.AddMinutes(1), signingCredentials: signinCredentials);
                //    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                //    return new JsonResult(new { message = "Success", data = new { token = tokenString, result = userDetail } }) { StatusCode = StatusCodes.Status200OK };
                //}
                //else
                //{
                //    return new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                //}

            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = ex.Message }) { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }
    }
}
