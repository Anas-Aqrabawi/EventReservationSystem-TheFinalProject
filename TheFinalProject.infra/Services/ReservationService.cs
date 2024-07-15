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
    public  class ReservationService:IReservationService
    {
        private readonly IReservationRespository _reservationRespository;

        public ReservationService(IReservationRespository reservationRespository)
        {
            _reservationRespository = reservationRespository;
        }

        public async Task CreateReservation(Reservation reservation)
        {
           await  _reservationRespository.CreateReservation(reservation);
        }

        public async Task DeleteReservation(int reservationId)
        {
          await  _reservationRespository.DeleteReservation(reservationId);
        }

        public async Task<Reservation> GetReservationById(int id)
        {
            return await _reservationRespository.GetReservationById(id);
        }

        public async Task<Reservation> GetReservationByUserId(int userID)
        {
            return await _reservationRespository.GetReservationByUserId(userID);
        }

        public async Task UpdateReservation(Reservation reservation)
        {
            await _reservationRespository.UpdateReservation(reservation);
        }
    }
}
