using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalProject.core.Data;

namespace TheFinalProject.core.IServices
{
    public interface IHallService
    {
        Task<List<Hall>> GetAllHalls();
        Task<Hall> GetHallById(int id);
        Task CreateHall(Hall hall);
        Task UpdateHall(Hall hall);
        Task DeleteHall(int id);
    }
}
