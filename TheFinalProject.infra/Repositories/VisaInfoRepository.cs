using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using TheFinalProject.core.Data;
using TheFinalProject.core.ICommon;
using TheFinalProject.core.IRepositories;

namespace TheFinalProject.infra.Repositories
{
    public class VisaInfoRepository : IVisaInfoRepository
    {
        private readonly IDbContext _dbContext;

        public VisaInfoRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Visainfo>> GetAllVisaInfo()
        {
            var result = await _dbContext.Connection
                .QueryAsync<Visainfo>("Payment_Pkg.Get_All_Payments",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Visainfo> GetVisaInfoById(int id)
        {
            var param = new DynamicParameters();
            param.Add("p_card_number", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Visainfo>("Payment_Pkg.Get_Payment_By_Id",
                param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task CreateVisaInfo(Visainfo visaInfo)
        {
            var param = new DynamicParameters();
            param.Add("p_cvc", visaInfo.Cvc, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("p_card_holder_name", visaInfo.CardHolderName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("p_card_number", visaInfo.CardNumber, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("p_user_id", visaInfo.UserId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("Payment_Pkg.Add_Payment", param, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateVisaInfo(Visainfo visaInfo)
        {
            var param = new DynamicParameters();
            param.Add("p_card_number", visaInfo.CardNumber, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("p_amount", visaInfo.Cvc, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            var status = await _dbContext.Connection.QuerySingleAsync<string>("Payment_Pkg.Update_Balance", param, commandType: CommandType.StoredProcedure);
            if (status != "UPDATED")
            {
                throw new Exception($"Update failed: {status}");
            }
        }

        public async Task DeleteVisaInfo(int id)
        {
            var param = new DynamicParameters();
            param.Add("p_card_number", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("Payment_Pkg.Delete_Payment", param, commandType: CommandType.StoredProcedure);
        }
    }
}
