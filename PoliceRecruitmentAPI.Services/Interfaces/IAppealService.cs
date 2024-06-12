using Microsoft.AspNetCore.Mvc;
using PoliceRecruitmentAPI.Core.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceRecruitmentAPI.Services.Interfaces
{
	public interface IAppealService
	{
		public Task<IActionResult> Get(AppealDto model);
		public Task<IActionResult> Appeal(AppealDto model);
	}
}
