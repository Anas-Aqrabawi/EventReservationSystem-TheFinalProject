using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalProject.core.Data;
using TheFinalProject.core.ICommon;
using TheFinalProject.core.IRepositories;

namespace TheFinalProject.infra.Repositories
{
    public class ReservationRepository:IReservationRespository
    {
        private readonly IDbContext _dbContext;

        public ReservationRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateReservation(Reservation reservation)
        {
            var param = new DynamicParameters();
            param.Add("reservationDate", reservation.ReservationDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            param.Add("reservationNotes", reservation.ReservationNotes, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("userID", reservation.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("hallID", reservation.HallId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("statusID", reservation.StatusId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("Reservations_package.CreateReservation", param
            ,commandType: CommandType.StoredProcedure);

        }

        public async Task DeleteReservation(int reservationId)
        {
            var param = new DynamicParameters();
            param.Add("reservationID", reservationId, DbType.Int32, ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("Reservations_package.DeleteReservation", 
                param, commandType: CommandType.StoredProcedure);
        }

        public async Task<Reservation> GetReservationById(int id)
        {
            try
            {
                //bag to send all parameters as one unit.
                var param = new DynamicParameters();
                param.Add("reservationID", id,
                    dbType: DbType.Int32,
                    direction: ParameterDirection.Input);

                var result = await _dbContext.Connection
                    .QueryAsync<Reservation>
                    ("Reservations_package.GetReservationByID"
                    , param, commandType:
                    CommandType.StoredProcedure);
                //one record returns.
                return result.FirstOrDefault()!;
            }
           
             catch (Exception ex)
                {
                // Log the exception
                Console.WriteLine($"Error fetching reservationID {id}: {ex.Message}");
                throw;
            }
        }
        //dto needs to be modified
        public async Task<Reservation> GetReservationByUserId(int userID)
        {
            var param = new DynamicParameters();
            param.Add("userID", userID, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Reservation>("Reservations_package.GetUserReservations", param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task UpdateReservation(Reservation reservation)
        {
            var param = new DynamicParameters();
            param.Add("reservationID", reservation.ReservationId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("reservationDate", reservation.ReservationDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            param.Add("reservationNotes", reservation.ReservationNotes, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("userID", reservation.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("hallID", reservation.HallId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("statusID", reservation.StatusId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("Reservations_package.EditReservation", param
            , commandType: CommandType.StoredProcedure);
        }
    }
}
