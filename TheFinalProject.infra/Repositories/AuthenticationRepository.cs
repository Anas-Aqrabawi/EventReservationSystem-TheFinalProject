using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalProject.core.DTOs;
using TheFinalProject.core.Enums;
using TheFinalProject.core.ICommon;
using TheFinalProject.core.IRepositories;

namespace TheFinalProject.infra.Repositories
{
    public class AuthenticationRepository: IAuthenticationRepository
    {
        private readonly IDbContext _dbContext;

        public AuthenticationRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task HallOwnerRegister(UserDTO userDto)
        {
            int userRole = (int)Roles.SystemRoles.Hall_Owner;

            var param = new DynamicParameters();

            param.Add("First_Name", userDto.Firstname, DbType.String, ParameterDirection.Input);
            param.Add("Last_Name", userDto.Lastname, DbType.String, ParameterDirection.Input);
            param.Add("Gender", userDto.Gender, DbType.String, ParameterDirection.Input);
            param.Add("ImagePath", userDto.ImagePath, DbType.String, ParameterDirection.Input);
            param.Add("Role_ID", userDto.Roleid = userRole, DbType.Int32, ParameterDirection.Input);
            param.Add("UserIdOut", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var result = await _dbContext.Connection.ExecuteAsync("Authentication_Package.Register", param, commandType: CommandType.StoredProcedure);

            int userId = param.Get<int>("UserIdOut");

            var newParam = new DynamicParameters();

            newParam.Add("UserEmail", userDto.Email, DbType.String, direction: ParameterDirection.Input);
            newParam.Add("UserPassword", userDto.Password, DbType.String, direction: ParameterDirection.Input);
            newParam.Add("UserID", userId, DbType.Int32, direction: ParameterDirection.Input);

            var result2 = await _dbContext.Connection.ExecuteAsync("Authentication_Package.AddCredentials", newParam, commandType: CommandType.StoredProcedure);
        }

        public async Task<UserLoginDTO> Login(UserCredentailsDTO userCredentailsDto)
        {
            var param = new DynamicParameters();

            param.Add("UserEmail", userCredentailsDto.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("UserPassword", userCredentailsDto.Password, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<UserLoginDTO>("Authentication_Package.Login", param, commandType: CommandType.StoredProcedure);

            return result.First();
        }

        public async Task Register(UserDTO userDto)
        {

            int userRole = (int)Roles.SystemRoles.User;

            var param = new DynamicParameters();

            param.Add("First_Name", userDto.Firstname, DbType.String, direction: ParameterDirection.Input);
            param.Add("Last_Name", userDto.Lastname, DbType.String, direction: ParameterDirection.Input);
            param.Add("Gender", userDto.Gender, DbType.String, direction: ParameterDirection.Input);
            param.Add("ImagePath", userDto.ImagePath, DbType.String, direction: ParameterDirection.Input);
            param.Add("Role_ID", userDto.Roleid = userRole, DbType.Int32, direction: ParameterDirection.Input);
            param.Add("UserIdOut", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var result = await _dbContext.Connection.ExecuteAsync("Authentication_Package.Register", param, commandType: CommandType.StoredProcedure);

            int userId = param.Get<int>("UserIdOut");

            var newParam = new DynamicParameters();

            newParam.Add("UserEmail", userDto.Email, DbType.String, direction: ParameterDirection.Input);
            newParam.Add("UserPassword", userDto.Password, DbType.String, direction: ParameterDirection.Input);
            newParam.Add("UserID", userId, DbType.Int32, direction: ParameterDirection.Input);

            var result2 = await _dbContext.Connection.ExecuteAsync("Authentication_Package.AddCredentials", newParam, commandType: CommandType.StoredProcedure);
        }

    }
}
