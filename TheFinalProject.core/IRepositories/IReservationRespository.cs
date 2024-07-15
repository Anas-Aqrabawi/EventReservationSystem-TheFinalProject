﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalProject.core.Data;

namespace TheFinalProject.core.IRepositories
{
    public interface IReservationRespository
    {
        Task CreateReservation(Reservation reservation);
        Task UpdateReservation(Reservation reservation);
        Task DeleteReservation(int reservationId);
        Task<Reservation> GetReservationByUserId(int userId);
        Task<Reservation> GetReservationById(int id);

    }
}
