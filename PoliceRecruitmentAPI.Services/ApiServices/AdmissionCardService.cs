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
	public class AdmissionCardService: IAdmissionCardService
	{
		AdmissionCardRepository _candidateRepository;
		public AdmissionCardService(AdmissionCardRepository candidateRepository)
		{
			_candidateRepository = candidateRepository;
		}
		public async Task<IActionResult> Get(CandidateDto model)
		{
			return await _candidateRepository.Get(model);

		}
	}
}
