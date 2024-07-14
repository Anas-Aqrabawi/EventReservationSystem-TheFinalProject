using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalProject.core.DTOs;
using TheFinalProject.core.ICommon;
using TheFinalProject.core.IRepositories;

namespace TheFinalProject.infra.Repositories
{
    public class UsersRepository: IUsersRepository
    {
        private readonly IDbContext _dbContext;

        public UsersRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> DeleteUserById(int id)
        {
            var param = new DynamicParameters();
            param.Add("UserId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("Users_Package.DeleteUserById", param, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<List<UserDTO>> GetAllHallOwners()
        {
            var result = await _dbContext.Connection.QueryAsync<UserDTO>("Users_Package.GetAllUsers", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<List<UserDTO>> GetAllRegisteredUsers()
        {
            var result = await _dbContext.Connection.QueryAsync<UserDTO>("Users_Package.GetAllUsers", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            var param = new DynamicParameters();
            param.Add("UserId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<UserDTO>("Users_Package.GetUserById", param, commandType: CommandType.StoredProcedure);

            return result.First();
        }

        public async Task UpdateUserInfo(UpdateUserDTO updateUser)
        {

            var param = new DynamicParameters();

            param.Add("UserID", updateUser.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("First_Name", updateUser.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Last_Name", updateUser.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("UserGender", updateUser.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("ImagePath", updateUser.ImagePath, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Role_ID", updateUser.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("UserIdOut", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var result = await _dbContext.Connection.ExecuteAsync("Users_Package.UpdateUserInfo", param, commandType: CommandType.StoredProcedure);

            int userId = param.Get<int>("UserIdOut");

            var newParam = new DynamicParameters();

            newParam.Add("UserEmail", updateUser.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            newParam.Add("UserPassword", updateUser.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            newParam.Add("UserID", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result2 = await _dbContext.Connection.ExecuteAsync("Users_Package.UpdateUserCredentials", newParam, commandType: CommandType.StoredProcedure);
        }
    }
}
