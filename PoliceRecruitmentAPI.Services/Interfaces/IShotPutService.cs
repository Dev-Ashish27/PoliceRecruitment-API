using Microsoft.AspNetCore.Mvc;
using PoliceRecruitmentAPI.Core.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceRecruitmentAPI.Services.Interfaces
{
	public interface IShotPutService
	{
		public Task<IActionResult> ShotPut(ShotPutDto model);

		public Task<IActionResult> Get(ShotPutDto model);
	}
}
