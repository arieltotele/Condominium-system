using Condominium_System.Data.Entities;
using Condominium_System.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Business.Services
{
    public class HousingFurnitureService : IHousingFurnitureService
    {
        private readonly IRepositoryNoId<HousingFurniture> _repository;

        public HousingFurnitureService(IRepositoryNoId<HousingFurniture> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<HousingFurniture>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<HousingFurniture> GetByIdsAsync(int housingId, int furnitureId)
        {
            return await _repository
                .FindAsync(hf => hf.HousingId == housingId && hf.FurnitureId == furnitureId, asNoTracking: true)
                .ContinueWith(t => t.Result.FirstOrDefault());
        }

        public async Task<HousingFurniture> CreateAsync(HousingFurniture entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int housingId, int furnitureId)
        {
            var entity = await GetByIdsAsync(housingId, furnitureId);
            if (entity != null)
            {
                _repository.Remove(entity);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(HousingFurniture entity)
        {
            var trackedEntity = _repository.Context.ChangeTracker
                .Entries<HousingFurniture>()
                .FirstOrDefault(e => e.Entity.HousingId == entity.HousingId && e.Entity.FurnitureId == entity.FurnitureId);

            if (trackedEntity != null)
            {
                trackedEntity.State = EntityState.Detached;
            }

            _repository.Update(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAllByHousingIdAsync(int housingId)
        {
            var items = await _repository
                .FindAsync(hf => hf.HousingId == housingId);

            _repository.RemoveRange(items);
            await _repository.SaveChangesAsync();
        }

        public async Task CreateRangeAsync(IEnumerable<HousingFurniture> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _repository.SaveChangesAsync();
        }

    }
}
