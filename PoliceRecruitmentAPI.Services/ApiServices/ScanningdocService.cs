using Microsoft.AspNetCore.Mvc;
using PoliceRecruitmentAPI.Core.ModelDtos;
using PoliceRecruitmentAPI.Core.Repository;
using PoliceRecruitmentAPI.Services.Interfaces;

namespace PoliceRecruitmentAPI.Services.ApiServices
{
    public class ScanningdocService : IScanningdocService
    {
        ScanningdocRepository _candidateRepository;
        public ScanningdocService(ScanningdocRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<IActionResult> Scanningdoc(ScanningdocDto model)
        {
            return await _candidateRepository.Scanningdoc(model);

        }
    }
}
