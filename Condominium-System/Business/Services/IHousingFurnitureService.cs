using Condominium_System.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Business.Services
{
    public interface IHousingFurnitureService
    {
        Task<IEnumerable<HousingFurniture>> GetAllAsync();
        Task<HousingFurniture> GetByIdsAsync(int housingId, int furnitureId);
        Task<HousingFurniture> CreateAsync(HousingFurniture entity);
        Task UpdateAsync(HousingFurniture entity);
        Task DeleteAsync(int housingId, int furnitureId);
        Task DeleteAllByHousingIdAsync(int housingId);
        Task CreateRangeAsync(IEnumerable<HousingFurniture> entities);

    }
}
