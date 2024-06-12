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
	public class ShotPutService:IShotPutService
	{
		ShotPutRepository _shotPutRepository;
		public ShotPutService(ShotPutRepository shotPutRepository)
		{
			_shotPutRepository = shotPutRepository;
		}
		public async Task<IActionResult> ShotPut(ShotPutDto model)
		{
			return await _shotPutRepository.ShotPut(model);

		}

		public async Task<IActionResult> Get(ShotPutDto model)
		{
			return await _shotPutRepository.Get(model);

		}
	}
}
