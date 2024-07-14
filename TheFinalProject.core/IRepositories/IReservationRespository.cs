using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalProject.core.Data;

namespace TheFinalProject.core.IRepositories
{
    public interface IReservationRespository
    {
        //Task<List<>> GetAllReservations();
        Task<Hall> GetReservationByUserId(int id);
        Task<Hall> GetReservationById(int id);
        Task CreateReservation(Hall hall);
        Task UpdateReservation(Hall hall);
        Task DeleteReservation(int id);
    }
}
