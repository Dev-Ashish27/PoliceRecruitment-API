using Microsoft.AspNetCore.Mvc;
using PoliceRecruitmentAPI.Core.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceRecruitmentAPI.Services.Interfaces
{
	public interface IRunningService
	{
		public Task<IActionResult> Get(RunningDto model);
		public Task<IActionResult> Running(RunningDto model);
		public Task<IActionResult> Get800(RunningDto model);
		public Task<IActionResult> Running800(RunningDto model);
		public Task<IActionResult> Get1600(RunningDto model);
		public Task<IActionResult> Running1600(RunningDto model);
	}
}
