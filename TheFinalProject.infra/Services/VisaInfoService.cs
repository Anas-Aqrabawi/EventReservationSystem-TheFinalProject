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
    public class VisaInfoService : IVisaInfoService
    {
        private readonly IVisaInfoRepository _visaInfoRepository;

        public VisaInfoService(IVisaInfoRepository visaInfoRepository)
        {
            _visaInfoRepository = visaInfoRepository;
        }

        public async Task<List<Visainfo>> GetAllVisaInfo()
        {
            return await _visaInfoRepository.GetAllVisaInfo();
        }

        public async Task<Visainfo> GetVisaInfoById(int id)
        {
            return await _visaInfoRepository.GetVisaInfoById(id);
        }

        public async Task CreateVisaInfo(Visainfo visaInfo)
        {
            await _visaInfoRepository.CreateVisaInfo(visaInfo);
        }

        public async Task UpdateVisaInfo(Visainfo visaInfo)
        {
            await _visaInfoRepository.UpdateVisaInfo(visaInfo);
        }

        public async Task DeleteVisaInfo(int id)
        {
            await _visaInfoRepository.DeleteVisaInfo(id);
        }
    }
}
