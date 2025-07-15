using Condominium_System.Data.Entities;
using Condominium_System.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Business.Services
{


    public class HousingServiceRelationService : IHousingServiceRelationService
    {
        private readonly IRepositoryNoId<HousingService> _repository;

        public HousingServiceRelationService(IRepositoryNoId<HousingService> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<HousingService>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<HousingService> GetByIdsAsync(int housingId, int serviceId)
        {
            return (await _repository.FindAsync(hs => hs.HousingId == housingId && hs.ServiceId == serviceId))
                   .FirstOrDefault();
        }

        public async Task<HousingService> CreateAsync(HousingService entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int housingId, int serviceId)
        {
            var entity = await GetByIdsAsync(housingId, serviceId);
            if (entity != null)
            {
                _repository.Remove(entity);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task DeleteAllByHousingIdAsync(int housingId)
        {
            var items = await _repository
                .FindAsync(hs => hs.HousingId == housingId);

            _repository.RemoveRange(items);
            await _repository.SaveChangesAsync();         
        }

        public async Task CreateRangeAsync(IEnumerable<HousingService> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _repository.SaveChangesAsync();
        }
    }
}
