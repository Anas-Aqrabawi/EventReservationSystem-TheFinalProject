using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheFinalProject.core.IServices;
using TheFinalProject.core.Data;

namespace TheFinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisaInfoController : ControllerBase
    {
        private readonly IVisaInfoService _visaInfoService;

        public VisaInfoController(IVisaInfoService visaInfoService)
        {
            _visaInfoService = visaInfoService;
        }

        [HttpGet]
        public async Task<List<Visainfo>> GetAllVisaInfo()
        {
            return await _visaInfoService.GetAllVisaInfo();
        }

        [HttpGet("{id}")]
        public async Task<Visainfo> GetVisaInfoById(int id)
        {
            return await _visaInfoService.GetVisaInfoById(id);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVisaInfo([FromBody] Visainfo visaInfo)
        {
            await _visaInfoService.CreateVisaInfo(visaInfo);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVisaInfo(int id, [FromBody] Visainfo visaInfo)
        {
            if (id != visaInfo.CardNumber)
            {
                return BadRequest();
            }
            await _visaInfoService.UpdateVisaInfo(visaInfo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisaInfo(int id)
        {
            await _visaInfoService.DeleteVisaInfo(id);
            return NoContent();
        }
    }
}
