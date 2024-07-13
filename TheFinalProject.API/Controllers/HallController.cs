using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheFinalProject.core.Data;
using TheFinalProject.core.IServices;

namespace TheFinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallController : ControllerBase
    {
        private readonly IHallService _hallService;

        public HallController(IHallService hallService)
        {
            _hallService = hallService;
        }
        [HttpPost]
        public async Task CreateHall(Hall hall)
        {
            await _hallService.CreateHall(hall);
        }
        [HttpDelete]
        public async Task DeleteHall(int id)
        {
            await _hallService.DeleteHall(id);
        }
        [HttpGet]
        public async Task<List<Hall>> GetAllHalls()
        {
            return await _hallService.GetAllHalls();
        }
        [HttpGet]
        [Route("GetHallById/{id}")]
        public async Task<Hall> GetHallById(int id)
        {
            return await _hallService.GetHallById(id);
        }
        [HttpPut]
        public async Task UpdateHall(Hall hall)
        {
            await _hallService.UpdateHall(hall);
        }
    }
}
