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
    public class HallRepository:IHallRepository
    {

        private readonly IDbContext _dbContext;

        public HallRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateHall(Hall hall)
        {
            var param = new DynamicParameters();
            param.Add("floorNumber", hall.FloorNumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("hall_name", hall.HallName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("hallNumber", hall.HallNumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("numberofTables", hall.NumberOfTables, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("numberofChairs", hall.NumberOfChairs, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("hallCapacity", hall.HallCapacity, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("hallIdentity", hall.HallIdentity, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("hallLocation", hall.HallLocation, dbType: DbType.String, direction: ParameterDirection.Input);
            //check out data type
            param.Add("hallPrice", hall.Price, dbType: DbType.Double, direction: ParameterDirection.Input);
            param.Add("hallAvailabilityDate", hall.HallAvailabilityDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            param.Add("hallServices", hall.Services, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Hmeridians", hall.Meridians, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("hallone_image_path", hall.Hall1ImagePath, DbType.String, ParameterDirection.Input);
            param.Add("halltwo_image_path", hall.Hall2ImagePath, DbType.String, ParameterDirection.Input);
            param.Add("hallthree_image_path", hall.Hall3ImagePath, DbType.String, ParameterDirection.Input);
            param.Add("hallfour_image_path", hall.Hall4ImagePath, DbType.String, ParameterDirection.Input);
            param.Add("hallfive_image_path", hall.Hall5ImagePath, DbType.String, ParameterDirection.Input);
            param.Add("hallsix_image_path", hall.Hall6ImagePath, DbType.String, ParameterDirection.Input);
            param.Add("hallseven_image_path", hall.Hall7ImagePath, DbType.String, ParameterDirection.Input);
            param.Add("HLetitude", hall.Latitude, DbType.String, ParameterDirection.Input);
            param.Add("userID", hall.UserId, DbType.Int32, ParameterDirection.Input);
            param.Add("statusID", hall.StatusId, DbType.Int32, ParameterDirection.Input);
            param.Add("isAvailable", hall.Isavailable, DbType.Int32, ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("Hall_package.CreateHall", param
               , commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteHall(int id)
        {
            var param = new DynamicParameters();
            param.Add("hallID", id,dbType: DbType.Int32,direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("Hall_package.DeleteHall", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Hall>> GetAllHalls()
        {
            var result = await _dbContext.Connection.QueryAsync<Hall>
                ("Hall_package.GetAllHalls", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Hall> GetHallById(int id)
        {
            var param = new DynamicParameters();
            param.Add("hallID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Hall>("Hall_package.GetHallById", param, commandType: CommandType.StoredProcedure);
            return result?.FirstOrDefault();
        }

        public async Task UpdateHall(Hall hall)
        {
            var param = new DynamicParameters();
            param.Add("hallID", hall.HallId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("hall_name", hall.HallName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("floorNumber", hall.FloorNumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("hallNumber", hall.HallNumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("numberofTables", hall.NumberOfTables, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("numberofChairs", hall.NumberOfChairs, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("hallCapacity", hall.HallCapacity, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("hallIdentity", hall.HallIdentity, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("hallLocation", hall.HallLocation, dbType: DbType.String, direction: ParameterDirection.Input);
            //check out data type
            param.Add("hallPrice", hall.Price, dbType: DbType.Double, direction: ParameterDirection.Input);
            param.Add("hallAvailabilityDate", hall.HallAvailabilityDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            param.Add("hallServices", hall.Services, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Hmeridians", hall.Meridians, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("hallone_image_path", hall.Hall1ImagePath, DbType.String, ParameterDirection.Input);
            param.Add("halltwo_image_path", hall.Hall2ImagePath, DbType.String, ParameterDirection.Input);
            param.Add("hallthree_image_path", hall.Hall3ImagePath, DbType.String, ParameterDirection.Input);
            param.Add("hallfour_image_path", hall.Hall4ImagePath, DbType.String, ParameterDirection.Input);
            param.Add("hallfive_image_path", hall.Hall5ImagePath, DbType.String, ParameterDirection.Input);
            param.Add("hallsix_image_path", hall.Hall6ImagePath, DbType.String, ParameterDirection.Input);
            param.Add("hallseven_image_path", hall.Hall7ImagePath, DbType.String, ParameterDirection.Input);
            param.Add("HLetitude", hall.Latitude, DbType.String, ParameterDirection.Input);
            param.Add("userID", hall.UserId, DbType.Int32, ParameterDirection.Input);
            param.Add("statusID", hall.StatusId, DbType.Int32, ParameterDirection.Input);
            param.Add("isAvailable", hall.Isavailable, DbType.Int32, ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("Hall_package.UpdateHallInformation", param
               , commandType: CommandType.StoredProcedure);

        }
    }
}
