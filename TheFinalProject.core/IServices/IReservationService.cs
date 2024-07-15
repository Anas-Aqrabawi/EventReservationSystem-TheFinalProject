using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalProject.core.Data;

namespace TheFinalProject.core.IServices
{
    public interface IReservationService
    {
        Task CreateReservation(Reservation reservation);
        Task UpdateReservation(Reservation reservation);
        Task DeleteReservation(int reservationId);
        Task<Reservation> GetReservationByUserId(int userID);
        Task<Reservation> GetReservationById(int id);
    }
}
