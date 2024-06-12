using Microsoft.AspNetCore.Mvc;
using PoliceRecruitmentAPI.Core.ModelDtos;

namespace PoliceRecruitmentAPI.Services.Interfaces
{
    public interface IScanningdocService
    {
        public Task<IActionResult> Scanningdoc(ScanningdocDto model);
    }
}
