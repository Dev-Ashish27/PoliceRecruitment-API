using Microsoft.AspNetCore.Mvc;
using PoliceRecruitmentAPI.Core.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceRecruitmentAPI.Services.Interfaces
{
	public interface IDocumentService
	{
		public Task<IActionResult> SaveDocument(DocumentDto model);
		public Task<IActionResult> Document(DocumentDto model);

	}
}
