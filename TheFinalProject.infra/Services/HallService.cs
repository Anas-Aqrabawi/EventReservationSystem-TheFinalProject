using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalProject.core.Data;
using TheFinalProject.core.IRepositories;
using TheFinalProject.core.IServices;

namespace TheFinalProject.infra.Services
{
    public class HallService:IHallService
    {
        private readonly IHallRepository _hallrepository;

        public HallService(IHallRepository hallrepository)
        {
            _hallrepository = hallrepository;
        }

        public async Task CreateHall(Hall hall)
        {
            await _hallrepository.CreateHall(hall);
        }

        public async Task DeleteHall(int id)
        {
            await _hallrepository.DeleteHall(id);
        }

        public async Task<List<Hall>> GetAllHalls()
        {
            return await _hallrepository.GetAllHalls();
        }

        public async Task<Hall> GetHallById(int id)
        {
            return await _hallrepository.GetHallById(id);
        }

        public async Task UpdateHall(Hall hall)
        {
            await _hallrepository.UpdateHall(hall);
        }
    }
}
