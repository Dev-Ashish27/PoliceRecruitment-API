using Microsoft.AspNetCore.Mvc;
using PoliceRecruitmentAPI.Core.ModelDtos;


namespace PoliceRecruitmentAPI.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<IActionResult> VerifyUser(LoginDto model);
    }
}
