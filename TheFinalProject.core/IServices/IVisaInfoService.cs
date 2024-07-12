using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalProject.core.Data;
namespace TheFinalProject.core.IServices
{
    public interface IVisaInfoService
    {
        Task<List<Visainfo>> GetAllVisaInfo();
        Task<Visainfo> GetVisaInfoById(int id);
        Task CreateVisaInfo(Visainfo visaInfo);
        Task UpdateVisaInfo(Visainfo visaInfo);
        Task DeleteVisaInfo(int id);
    }
}
