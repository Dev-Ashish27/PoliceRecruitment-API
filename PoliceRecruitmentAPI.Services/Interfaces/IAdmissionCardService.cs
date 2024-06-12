using Microsoft.AspNetCore.Mvc;
using PoliceRecruitmentAPI.Core.ModelDtos;

namespace PoliceRecruitmentAPI.Services.Interfaces
{
	public interface IAdmissionCardService
	{
		public Task<IActionResult> Get(CandidateDto model);
	}
}
