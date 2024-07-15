using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheFinalProject.core.Data;
using TheFinalProject.core.IServices;
using TheFinalProject.infra.Services;

namespace TheFinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public async Task CreateReservation(Reservation reservation)
        {
            await _reservationService.CreateReservation(reservation);
        }
        [HttpDelete]
        public async Task DeleteReservation(int reservationId)
        {
            await _reservationService.DeleteReservation(reservationId);
        }

        [HttpPut]
        public async Task UpdateReservation(Reservation reservation)
        {
            await _reservationService.UpdateReservation(reservation);
        }

        [HttpGet]
        [Route("GetReservationByUserId/{userID}")]
        public async Task<Reservation> GetReservationByUserId(int userID)
        {
            return await _reservationService.GetReservationByUserId(userID);
        }
        [HttpGet]
        [Route("GetReservationById/{id}")]
        public async Task<Reservation> GetReservationById(int id)
        {
            return await _reservationService.GetReservationById(id);
        }
    }
}
