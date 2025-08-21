using Condominium_System.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Business.Services
{
    public interface IHousingServiceRelationService
    {
        Task<IEnumerable<HousingService>> GetAllAsync();
        Task<HousingService> GetByIdsAsync(int housingId, int serviceId);
        Task<HousingService> CreateAsync(HousingService entity);
        Task DeleteAsync(int housingId, int serviceId);
        Task DeleteAllByHousingIdAsync(int housingId);
        Task CreateRangeAsync(IEnumerable<HousingService> entities);
    }
}
