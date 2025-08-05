using Condominium_System.Data.Entities;
using Condominium_System.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Business.Services
{
    public class HousingEntityService : IHousingEntityService
    {
        private readonly IRepositoryWithId<Housing> _housingRepository;

        public HousingEntityService(IRepositoryWithId<Housing> housingRepository)
        {
            _housingRepository = housingRepository;
        }

        public async Task<IEnumerable<Housing>> GetAllHousingsAsync()
        {
            return await _housingRepository.GetAllWithIncludesAsync(
                h => h.Block,
                h => h.Services,
                h => h.Furnitures,
                h => h.Tenants
            );
        }

        public async Task<Housing> GetHousingByIdAsync(int id)
        {
            return await _housingRepository.GetByIdWithIncludesAsync(
                id,
                h => h.Block,
                h => h.Services,
                h => h.Furnitures,
                h => h.Tenants
            );
        }

        public async Task<IEnumerable<Housing>> SearchHousingsAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await GetAllHousingsAsync();
            }

            if (searchTerm.All(char.IsDigit) && int.TryParse(searchTerm, out int id))
            {
                var housing = await GetHousingByIdAsync(id);
                return housing != null ? new List<Housing> { housing } : Enumerable.Empty<Housing>();
            }
            else
            {
                return await _housingRepository.FindAsync(h =>
                    h.Code.Contains(searchTerm));
            }
        }

        public async Task<Housing> CreateHousingAsync(Housing housing)
        {
            await _housingRepository.AddAsync(housing);
            await _housingRepository.SaveChangesAsync();
            return housing;
        }

        public async Task UpdateHousingAsync(Housing housing)
        {
            _housingRepository.Update(housing);
            await _housingRepository.SaveChangesAsync();
        }

        public async Task DeleteHousingAsync(int id)
        {
            var housing = await _housingRepository.GetByIdAsync(id);
            if (housing != null)
            {
                _housingRepository.Remove(housing);
                await _housingRepository.SaveChangesAsync();
            }
        }
    }
}
