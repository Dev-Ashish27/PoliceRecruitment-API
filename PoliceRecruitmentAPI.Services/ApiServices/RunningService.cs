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
	public class RunningService: IRunningService
	{
		RunningRepository _candidateRepository;
		public RunningService(RunningRepository candidateRepository)
		{
			_candidateRepository = candidateRepository;
		}
		public async Task<IActionResult> Get(RunningDto model)
		{
			return await _candidateRepository.Get(model);

		}
		public async Task<IActionResult> Running(RunningDto model)
		{
			return await _candidateRepository.Running(model);

		}
		public async Task<IActionResult> Get800(RunningDto model)
		{
			return await _candidateRepository.Get800(model);

		}
		public async Task<IActionResult> Running800(RunningDto model)
		{
			return await _candidateRepository.Running800(model);

		}
		public async Task<IActionResult> Get1600(RunningDto model)
		{
			return await _candidateRepository.Get1600(model);

		}
		public async Task<IActionResult> Running1600(RunningDto model)
		{
			return await _candidateRepository.Running1600(model);

		}
	}
}
