using Microsoft.AspNetCore.Mvc;
using PoliceRecruitmentAPI.Core.ModelDtos;
using PoliceRecruitmentAPI.Core.Repository;
using PoliceRecruitmentAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceRecruitmentAPI.Services.ApiServices
{
	public class AppealService: IAppealService
	{
		AppealRepository _candidateRepository;
		public AppealService(AppealRepository candidateRepository)
		{
			_candidateRepository = candidateRepository;
		}
		public async Task<IActionResult> Get(AppealDto model)
		{
			return await _candidateRepository.Get(model);

		}
		public async Task<IActionResult> Appeal(AppealDto model)
		{
			return await _candidateRepository.Appeal(model);

		}
	}
}
