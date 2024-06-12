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
	public class DocumentService:IDocumentService
	{
		DocumentRepository _DocRepository;
		public DocumentService(DocumentRepository docRepository)
		{
			_DocRepository = docRepository;
		}
		public async Task<IActionResult> SaveDocument(DocumentDto model)
		{
			return await _DocRepository.SaveDocument(model);

		}
		public async Task<IActionResult> Document(DocumentDto model)
		{
			return await _DocRepository.Document(model);

		}
	}
}
